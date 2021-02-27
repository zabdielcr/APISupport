using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Service
    {
        public Service()
        {
            ServiceSupports = new HashSet<ServiceSupport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ServiceSupport> ServiceSupports { get; set; }
    }
}
