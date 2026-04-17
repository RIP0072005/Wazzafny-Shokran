using System;
using System.Collections.Generic;
using System.Text;

namespace Wazifny.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public  ICollection<Graduate> Graduates { get; set; }
        public  ICollection<Job> Jobs { get; set; }
    }
}
