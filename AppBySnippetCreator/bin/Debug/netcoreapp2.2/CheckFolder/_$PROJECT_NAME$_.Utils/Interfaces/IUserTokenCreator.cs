using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils.Interfaces
{
    public interface IUserTokenCreator
    {
        string CreateToken(string model);
        string DecodeToken(string token);
    }
}
