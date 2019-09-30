using _$PROJECT_NAME$_.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils.User
{
    public class UserPasswordDoubleBase64Encoder : IUserPasswordEncoder
    {
        public string EncodeUserPassword(string password)
        {
            var ft = Convert.ToBase64String(Encoding.Default.GetBytes(password));
            return Convert.ToBase64String(Encoding.Default.GetBytes(ft));
        }
    }
}
