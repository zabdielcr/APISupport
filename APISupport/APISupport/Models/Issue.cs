using System;
using System.Collections.Generic;

#nullable disable

namespace APISupport.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Notes = new HashSet<Note>();
            Services = new HashSet<Service>();
        }

        public int ReportNumber { get; set; }
        public string Classification { get; set; }
        public string Status { get; set; }
        public byte[] ReportTimestamp { get; set; }
        public string ResolutionComment { get; set; }
        public string IdSupporter { get; set; }

        public virtual Supporter IdSupporterNavigation { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
