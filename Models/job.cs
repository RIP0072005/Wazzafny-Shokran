using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Models
{
    public enum JobType { FullTime, PartTime, Remote, OnSite }

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public JobType Type { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;

        
        public int EmployerId { get; set; }
        public  Employer Employer { get; set; }

        
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Skill> RequiredSkills { get; set; }
    }
}
