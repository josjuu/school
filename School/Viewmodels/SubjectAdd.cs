﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DAL;
using School.WEB.Helpers;

namespace School.WEB.Viewmodels
{
    public class SubjectAdd
    {
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Subject must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter in the subjects name.")]
        [Display(Name = "Enter the subjects name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A teacher must be selected for the subject.")]
        [Display(Name = "Choose the teacher:")]
        public int TeacherId { get; set; }

        public IEnumerable<SelectListItem> Teachers { get; set; }

        public SubjectAdd()
        {
            using (var db = new SchoolContext())
            {
                Teachers = db.Teachers
                    .OrderBy(t => t.Lastname)
                    .ThenBy(t => t.Firstname)
                    .Select(teacher => new SelectListItem
                    {
                        Text = teacher.GetFullname(),
                        Value = teacher.Id.ToString()
                    })
                    .ToList();
            }
        }
    }
}