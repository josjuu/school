using System.ComponentModel.DataAnnotations;

namespace School.DAL.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}