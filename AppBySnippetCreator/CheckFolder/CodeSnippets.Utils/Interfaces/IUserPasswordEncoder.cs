using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Utils.Interfaces
{
    public interface IUserPasswordEncoder
    {
        string EncodeUserPassword(string password);
    }
}
