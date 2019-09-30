using CodeSnippets.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Entities.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public ICollection<Snippet> Snippets { get; set; }
    }
    public enum AccessLevel : byte
    {
        USER = 0,
        MODERATOR = 1,
        ADMINISTRATOR = 2
    }
}
