using System;
using System.Collections.Generic;

#nullable disable

namespace APISupport.Models
{
    public partial class Supervisor
    {
        public Supervisor()
        {
            Supporters = new HashSet<Supporter>();
        }

        public string Name { get; set; }
        public string FirtsSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Supporter> Supporters { get; set; }
    }
}
