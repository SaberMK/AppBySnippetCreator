using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Utils.Interfaces
{
    public interface IUserTokenCreator
    {
        string CreateToken(string model);
        string DecodeToken(string token);
    }
}
