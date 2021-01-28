using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Supporter
    {

        private int id;
        private string name;
        private string firstSurname;
        private string secondSurname;
        private string email;
        private string password;
        private string role;
        private string idSupervisor;

        public Supporter(int id, string name, string firstSurname, string secondSurname, string email, string password, string role, string idSupervisor)
        {
            this.id = id;
            this.name = name;
            this.firstSurname = firstSurname;
            this.secondSurname = secondSurname;
            this.email = email;
            this.password = password;
            this.role = role;
            this.idSupervisor = idSupervisor;
        }

        public  Supporter()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FirstSurname { get => firstSurname; set => firstSurname = value; }
        public string SecondSurname { get => secondSurname; set => secondSurname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string IdSupervisor { get => idSupervisor; set => idSupervisor = value; }
    }
}
