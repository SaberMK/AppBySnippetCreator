using AutoMapper;
using _$PROJECT_NAME$_.Database.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories.M2MMappings.Interfaces;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.Entities.Entities.M2MMappings;
using _$PROJECT_NAME$_.Services.Interfaces;
using _$PROJECT_NAME$_.Utils;
using _$PROJECT_NAME$_.Utils.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Services
{
    [DependencyInjection(typeof(IUserService), DependencyInjectionScope.Scoped)]
    public class UserService : IUserService
    {
        readonly IMapper _mapper;
        readonly IUserRepository _userRepository;
        readonly IUserPasswordEncoder _encoder;

        ISnippetRepository _snippetRepository;
        ILanguageRepository _languageRepository;
        ISnippetTagRepository _snippetTagRepository;
        ITagRepository _tagRepository;
        public UserService(IMapper mapper, IUserRepository userContext, IUserPasswordEncoder encoder
            , ISnippetRepository snippetRepository, ILanguageRepository languageRepository,
        ISnippetTagRepository snippetTagRepository, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _encoder = encoder;
            _userRepository = userContext;

            _snippetRepository = snippetRepository;
            _languageRepository = languageRepository;
            _snippetRepository = snippetRepository;
            _snippetTagRepository = snippetTagRepository;
            _tagRepository = tagRepository;
        }
        public async Task<bool> IsUserExists(string username)
        {
            var user = await _userRepository.Query().SingleOrDefaultAsync(x => x.Username == username);
            return user != null;   
        }

        public async Task<User> AuthUser(string username, string password)
        {
            try
            {
                return await _userRepository.Query().SingleAsync(x => x.Username == username && x.Password == _encoder.EncodeUserPassword(password));
            }
            catch //TODO
            {
                return null;
            }
        }

        public async Task<User> RegisterUser(string username, string password)
        {
            try
            {
                await _userRepository.AddAsync(new User()
                {
                    Username = username,
                    Password = _encoder.EncodeUserPassword(password),
                    RegistrationDate = DateTime.Now
                });
                await _userRepository.CommitAsync();

                return await _userRepository.Query().SingleAsync(x => x.Username == username);
            }
            catch //TODO
            {
                return null;
            }
        }

        public async Task<User> GetUserById(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
