using System.ComponentModel.DataAnnotations;
using School.DAL.Models;
using School.WEB.Helpers;

namespace School.WEB.Viewmodels
{
    public class StudentUpdate
    {
        [Display(Name = "The id of the student:")]
        public int Id { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the students firstname:")]
        public string Firstname { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the students lastname:")]
        public string Lastname { get; set; }

        public string Fullname { get; set; }

        public StudentUpdate()
        {
        }

        public StudentUpdate(int id)
        {
            var student = GetDatabaseObjects.GetObjectById<Student>(id);

            Id = id;
            Firstname = student.Firstname;
            Lastname = student.Lastname;
            Fullname = student.GetFullname();
        }
    }
}