﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSupport.Models.Domain
{
    public class Student
    {

        private int studentId;
        private string name;
        private string email;
        private string password;

        public Student(int studentId, string name, string email, string password)
        {
            this.studentId = studentId;
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public Student()
        {
        }

        public int StudentId { get => studentId; set => studentId = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
