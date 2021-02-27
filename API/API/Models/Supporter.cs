using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Supporter
    {
        public Supporter()
        {
            Assignments = new HashSet<Assignment>();
            ServiceSupports = new HashSet<ServiceSupport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public int IdService { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<ServiceSupport> ServiceSupports { get; set; }
    }
}
