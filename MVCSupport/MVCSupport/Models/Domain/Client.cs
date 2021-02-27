using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Client
    {
        private int id;
        private string name;
        private string firstName;
        private string secondName;
        private string address;
        private string phone;
        private string secondContact;
        private string email;

        public Client()
        {
        }

        public Client(int id, string name, string firstName, string secondName, string address, string phone, string secondContact, string email)
        {
            this.Id = id;
            this.Name = name;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Address = address;
            this.Phone = phone;
            this.SecondContact = secondContact;
            this.Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string SecondContact { get => secondContact; set => secondContact = value; }
        public string Email { get => email; set => email = value; }
    }
}
