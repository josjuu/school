using System.ComponentModel.DataAnnotations;
using School.DAL.Models;
using School.WEB.Helpers;

namespace School.WEB.Viewmodels
{
    public class TeacherUpdate
    {
        [Display(Name = "The id of the teacher:")]
        public int Id { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the teachers firstname:")]
        public string Firstname { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the teachers lastname:")]
        public string Lastname { get; set; }

        public string Fullname { get; set; }

        public TeacherUpdate()
        {
        }

        public TeacherUpdate(int id)
        {
            var teacher = GetDatabaseObjects.GetObjectById<Teacher>(id);

            Id = id;
            Firstname = teacher.Firstname;
            Lastname = teacher.Lastname;
            Fullname = teacher.GetFullname();
        }
    }
}