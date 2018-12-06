﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DementiaProject_Two.Models.Account
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RepeatPassword { get; set; }
    }
}
