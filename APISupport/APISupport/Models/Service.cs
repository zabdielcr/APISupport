using System;
using System.Collections.Generic;

#nullable disable

namespace APISupport.Models
{
    public partial class Service
    {
        public int IdService { get; set; }
        public string Name { get; set; }
        public string IdSupporter { get; set; }
        public int? IdIssue { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
        public virtual Supporter IdSupporterNavigation { get; set; }
    }
}
