using System.ComponentModel.DataAnnotations;

namespace School.WEB.Viewmodels
{
    public class TeacherAdd
    {
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the teachers firstname:")]
        public string Firstname { get; set; }

        [StringLength(64, MinimumLength = 3, ErrorMessage = "Name must be between {2} and {1} characters long.")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Enter the teachers lastname:")]
        public string Lastname { get; set; }
    }
}