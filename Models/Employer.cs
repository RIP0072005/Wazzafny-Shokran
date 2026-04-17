using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Models
{
    public class Employer : User
    {
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }

      
        public  ICollection<Job> Jobs { get; set; }
    }
}