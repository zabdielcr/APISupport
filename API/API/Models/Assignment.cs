using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Assignment
    {
        public int IdIssue { get; set; }
        public int IdSupporter { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
        public virtual Supporter IdSupporterNavigation { get; set; }
    }
}
