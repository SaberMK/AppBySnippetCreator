using CodeSnippets.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Utils.User
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
