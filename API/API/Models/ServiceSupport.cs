using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ServiceSupport
    {
        public int IdSupport { get; set; }
        public int IdService { get; set; }

        public virtual Service IdServiceNavigation { get; set; }
        public virtual Supporter IdSupportNavigation { get; set; }
    }
}
