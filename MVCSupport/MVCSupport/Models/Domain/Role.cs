using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Role
    {
        private int id;
        private string name;
        public Role()
        {
        }

        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
