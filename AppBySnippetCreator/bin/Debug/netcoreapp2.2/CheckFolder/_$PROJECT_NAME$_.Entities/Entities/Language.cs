using _$PROJECT_NAME$_.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Entities.Entities
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
