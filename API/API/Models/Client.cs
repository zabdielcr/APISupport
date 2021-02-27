using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Client
    {
        public Client()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SecondContact { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
