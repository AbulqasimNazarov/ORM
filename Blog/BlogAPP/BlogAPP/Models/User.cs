﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImagePath { get; set;}
        public int? Gender { get; set;}


        public override string ToString() => $@"Name: {Name} 
Surname: {Surname} 
Email: {Email}";
    }
}
