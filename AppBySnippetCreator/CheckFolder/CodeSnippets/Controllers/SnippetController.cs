using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using CodeSnippets.ViewModels.Request.Snippet;
using CodeSnippets.ViewModels.Response.Snippet;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeSnippets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("hah")]
    public class SnippetController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IUserTokenCreator _tokenCreator;
        readonly IResponseCreator _responseCreator;
        readonly ITagService _tagService;
        readonly ISnippetService _snippetService;
        readonly ILanguageService _languageService;
        readonly IMapper _mapper;
        public SnippetController(IUserService userService, IUserTokenCreator tokenCreator,
            IResponseCreator responseCreator, ITagService tagService,
            ISnippetService snippetService, ILanguageService languageService,
            IMapper mapper)
        {
            _userService = userService;
            _tokenCreator = tokenCreator;
            _responseCreator = responseCreator;
            _tagService = tagService;
            _snippetService = snippetService;
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addSnippet")]
        public async Task<ResponseViewModel> AddSnippet([FromBody]AddSnippetViewModel addSnippetViewModel)
        {
            var user = JsonConvert.DeserializeObject<User>(_tokenCreator.DecodeToken(addSnippetViewModel.Token));
            if (user == null)
                return _responseCreator.CreateFailure("Bad user token!");

            var tags = await _tagService.AddOrUpdateTags(addSnippetViewModel.Tags);
            var language = _languageService.GetLanguageByContent(addSnippetViewModel.Language);

            if (language == null)
                return _responseCreator.CreateFailure("Bad language!");

            var snippet = await _snippetService.AddSnippet(addSnippetViewModel.Name, addSnippetViewModel.Description, addSnippetViewModel.Code,
                                            user, language, tags);

            return _responseCreator.CreateSuccess("Snippet added successfully");
        }

        [HttpGet]
        [Route("getSnippet")]
        public async Task<ResponseViewModel> GetSnippet(int id)
        {
            var snippet = await _snippetService.GetSnippetById(id);
            if (snippet == null)
                return _responseCreator.CreateFailure("Snippet not found!");

            var snippetViewModel = _mapper.Map<Snippet, SnippetViewModel>(snippet);
            snippetViewModel = _mapper.Map<User, SnippetViewModel>(await _userService.GetUserById(snippet.UserId), snippetViewModel);

            var tags = await _snippetService.GetTagsBySnippet(snippet);

            if (tags != null)
                snippetViewModel.Tags = tags.Select(x => x.Content).ToArray();

            snippetViewModel.Language = await _languageService.GetLanguageTextById(snippet.LanguageId);

            return _responseCreator.CreateSuccess(snippetViewModel);
        }
    }
}