using System;
using System.Collections.Generic;

#nullable disable

namespace AppiSupport1.Models
{
    public partial class Supporter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int IdSupervisor { get; set; }
    }
}
