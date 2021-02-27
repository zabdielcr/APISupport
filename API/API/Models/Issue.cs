using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int ReportNumber { get; set; }
        public string Classification { get; set; }
        public string Status { get; set; }
        public byte[] ReportTimestamp { get; set; }
        public string ResolutionComment { get; set; }
        public int IdClient { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
