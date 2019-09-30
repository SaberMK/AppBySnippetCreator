using CodeSnippets.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Utils.User
{
    public class UserPasswordBase64Encoder : IUserPasswordEncoder
    {
        public string EncodeUserPassword(string password)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(password));
        }
    }
}
