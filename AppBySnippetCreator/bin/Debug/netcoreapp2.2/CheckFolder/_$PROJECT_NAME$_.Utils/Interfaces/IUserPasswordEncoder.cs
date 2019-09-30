using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils.Interfaces
{
    public interface IUserPasswordEncoder
    {
        string EncodeUserPassword(string password);
    }
}
