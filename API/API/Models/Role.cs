using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Role
    {
        public Role()
        {
            Supporters = new HashSet<Supporter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Supporter> Supporters { get; set; }
    }
}
