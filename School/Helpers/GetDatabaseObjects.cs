using System.Collections;
using System.Linq;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Helpers
{
    public class GetDatabaseObjects
    {
        public static T GetObjectById<T>(int id) where T : class
        {
            using (var db = new SchoolContext())
            {
                var record = db.Set<T>().Find(id);
                return record;
            }
        }

        public static IEnumerable GetStudentsOfSubject(int subjectId)
        {
            using (var db = new SchoolContext())
            {
                var studentIds = db.StudentSubjects.Where(s => s.SubjectId == subjectId).Select(s => s.StudentId);
                var students = db.Students.Where(s => studentIds.Contains(s.Id)).ToList();

                return students;
            }
        }

        public static Teacher GetTeacherOfSubject(int subjectId)
        {
            using (var db = new SchoolContext())
            {
                var subject = db.Subjects.SingleOrDefault(s => s.Id == subjectId);

                return subject != null
                    ? db.Teachers.SingleOrDefault(t => t.Id == subject.TeacherId)
                    : null;
            }
        }
    }
}