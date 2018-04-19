using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DAL.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string SubjectName { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}