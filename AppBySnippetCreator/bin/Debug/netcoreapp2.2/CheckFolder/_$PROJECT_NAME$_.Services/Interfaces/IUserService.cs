using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using _$PROJECT_NAME$_.Entities.Entities;

namespace _$PROJECT_NAME$_.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string username);
        Task<User> AuthUser(string username, string password);
        Task<User> RegisterUser(string username, string password);
        Task<User> GetUserById(long id);
    }
}
