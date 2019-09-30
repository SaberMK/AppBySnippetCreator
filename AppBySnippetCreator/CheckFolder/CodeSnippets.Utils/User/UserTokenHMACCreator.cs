using CodeSnippets.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace CodeSnippets.Utils.User
{
    public class UserTokenHMACCreator : IUserTokenCreator
    {
        readonly string _key;
        public UserTokenHMACCreator(string key)
        {
            _key = key;
        }
        public string CreateToken(string model)
        {
            return new HmacSerializer<string>(_key).Serialize(model);
        }

        public string DecodeToken(string token)
        {
            return new HmacSerializer<string>(_key).Deserialize(token);
        }
    }
}
