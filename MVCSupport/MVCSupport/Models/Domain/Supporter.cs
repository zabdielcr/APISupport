using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Supporter
    {

        //private int id;
        private string name;
        private string firstSurname;
        private string secondSurname;
        private string email;
        private string password;
        private int role;
        private int service;


      

        public  Supporter()
        {
        }

        public Supporter(string name, string firstSurname, string secondSurname, string email, string password, int role, int service)
        {
         
            this.Name = name;
            this.FirstSurname = firstSurname;
            this.SecondSurname = secondSurname;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.Service = service;
        }

       // public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FirstSurname { get => firstSurname; set => firstSurname = value; }
        public string SecondSurname { get => secondSurname; set => secondSurname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public int Service { get => service; set => service = value; }
    }
}
