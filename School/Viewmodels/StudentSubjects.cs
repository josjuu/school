using System.Collections.Generic;
using System.Linq;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Viewmodels
{
    public class StudentSubjects
    {
        public Student Student { get; }
        public List<Subject> SubjectsOfStudent { get; }
        public List<Subject> RemainingSubjects { get; }

        public StudentSubjects(int studentId)
        {
            using (var db = new SchoolContext())
            {
                Student = db.Students.SingleOrDefault(s => s.Id == studentId);
                var studentSubjects = db.StudentSubjects.Where(ss => ss.StudentId == studentId).ToList();

                SubjectsOfStudent = new List<Subject>();
                RemainingSubjects = new List<Subject>();

                foreach (var studentSubject in studentSubjects)
                    SubjectsOfStudent.Add(db.Subjects.Single(s => s.Id == studentSubject.SubjectId));

                RemainingSubjects = db.Subjects.Where(s => !SubjectsOfStudent.Contains(s)).ToList();
            }
        }
    }
}