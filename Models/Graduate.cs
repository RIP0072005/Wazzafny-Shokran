using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Models
{
    public class Graduate : User
    {
        public string Summary { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string CVPath { get; set; } 

        
        public  ICollection<Application> Applications { get; set; }
        public  ICollection<Skill> Skills { get; set; }
    }
}
