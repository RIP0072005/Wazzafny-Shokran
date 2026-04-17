using System;
using System.Collections.Generic;
using System.Text;

namespace Wazifny.Models
{
    public enum UserRole { Graduate, Employer, Admin }

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public UserRole Role { get; set; } 

       
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
