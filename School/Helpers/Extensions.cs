using System.Linq;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Helpers
{
    public static class Extensions
    {
        public static string GetFullname(this Student student)
        {
            return $"{student.Firstname} {student.Lastname}";
        }

        public static string GetFullname(this Teacher teacher)
        {
            return $"{teacher.Firstname} {teacher.Lastname}";
        }

        public static string GetTeachersName(this Subject subject)
        {
            using (var db = new SchoolContext())
            {
                var teacher = db.Teachers.SingleOrDefault(t => t.Id == subject.TeacherId);

                return teacher?.GetFullname();
            }
        }
    }
}