﻿using System.ComponentModel.DataAnnotations;

namespace OlxWebApplication.Models.User
{
    public class SignUpUserModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        //[Required]
        //public string EmployeeRole { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}