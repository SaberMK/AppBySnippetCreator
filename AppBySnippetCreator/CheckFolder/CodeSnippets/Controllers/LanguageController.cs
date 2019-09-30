using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using CodeSnippets.ViewModels.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeSnippets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("hah")]
    public class LanguageController : ControllerBase
    {
        readonly ILanguageService _languageService;
        readonly IUserTokenCreator _tokenCreator;
        readonly IResponseCreator _responseCreator;

        public LanguageController(ILanguageService languageService, IMapper mapper, 
            IUserTokenCreator tokenCreator, IResponseCreator responseCreator)
        {
            _languageService = languageService;
            _tokenCreator = tokenCreator;
            _responseCreator = responseCreator;
        }

        [HttpPost]
        [Route("getLanguages")]
        public ActionResult<ResponseViewModel> GetLanguages([FromBody]TokenViewModel tokenModel)
        {
            var user = JsonConvert.DeserializeObject<User>(_tokenCreator.DecodeToken(tokenModel.Token));
            if (user == null)
                return _responseCreator.CreateFailure("Bad user token!");

            var languages = _languageService.GetAllLanguages().ToArray();
            return _responseCreator.CreateSuccess(languages);
        }
    }
}