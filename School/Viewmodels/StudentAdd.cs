﻿using System.ComponentModel.DataAnnotations;

namespace School.WEB.Viewmodels
{
    public class StudentAdd
    {
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the students firstname:")]
        public string Firstname { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the students lastname:")]
        public string Lastname { get; set; }
    }
}