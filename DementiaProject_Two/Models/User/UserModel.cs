﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaProject_Two.Models.User
{
    public class UserModel 
    {
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        public int Age { get; set; }

        [Range(1000,9999)]
        public int ZipCode { get; set; }
        public Gender GenderType { get; set; }
        //public byte[] Picture { get; set; }
        public string Email { get; set; }
        public Guid IdentityFK { get; set; } 
    }

    public enum Gender
    {
        Male,
        Female,
        Binary,
        Feline
    }
}
