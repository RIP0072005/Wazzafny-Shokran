using System;
using System.Collections.Generic;
using System.Text;

namespace Wazifny.Models
{
    public enum ApplicationStatus { Pending, Interview, Accepted, Rejected }

    public class Application
    {
        public int Id { get; set; }
        public DateTime ApplyDate { get; set; } = DateTime.Now;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public int JobId { get; set; }
        public  Job Job { get; set; }

        public int GraduateId { get; set; }
        public  Graduate Graduate { get; set; }
    }
}
