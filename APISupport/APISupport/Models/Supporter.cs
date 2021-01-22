using System;
using System.Collections.Generic;

#nullable disable

namespace APISupport.Models
{
    public partial class Supporter
    {
        public Supporter()
        {
            Issues = new HashSet<Issue>();
            Services = new HashSet<Service>();
        }

        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string IdSupervisor { get; set; }

        public virtual Supervisor IdSupervisorNavigation { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
