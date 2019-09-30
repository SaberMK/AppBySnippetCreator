using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using _$PROJECT_NAME$_.Services.Interfaces;
using _$PROJECT_NAME$_.Utils.Interfaces;
using _$PROJECT_NAME$_.Utils.ResponseCreators;
using _$PROJECT_NAME$_.ViewModels.Request.User;
using _$PROJECT_NAME$_.ViewModels.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _$PROJECT_NAME$_.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [EnableCors("hah")]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        readonly IUserTokenCreator _tokenCreator;
        readonly IResponseCreator _responseCreator;
        public UserController(IUserService userService, IMapper mapper, IUserTokenCreator tokenCreator, IResponseCreator responseCreator)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenCreator = tokenCreator;
            _responseCreator = responseCreator;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<ResponseViewModel>> Auth([FromBody]UserAuthViewModel request)
        {
            if (!await _userService.IsUserExists(request.Username))
                return _responseCreator.CreateFailure("This user doesn't exist");

            var user = await _userService.AuthUser(request.Username, request.Password);
            var tokenModel = _mapper.Map<UserTokenViewModel>(user);

            tokenModel.Token = _tokenCreator.CreateToken(JsonConvert.SerializeObject(user));
            return _responseCreator.CreateSuccess(tokenModel);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseViewModel>> Register([FromBody]UserRegisterViewModel request)
        {
            if (request.Password != request.PasswordConfirmation)
                return _responseCreator.CreateFailure("Passwords aren't equal");

            if (await _userService.IsUserExists(request.Username))
                return _responseCreator.CreateFailure("User exists");
            
            var user = await _userService.RegisterUser(request.Username, request.Password);

            if (user == null)
                return _responseCreator.CreateFailure("Exception, dunno what exception it is, need to throw them and catch...");

            var tokenModel = _mapper.Map<UserTokenViewModel>(user);

            tokenModel.Token = _tokenCreator.CreateToken(JsonConvert.SerializeObject(user));
            return _responseCreator.CreateSuccess(tokenModel);
        }
    }
}