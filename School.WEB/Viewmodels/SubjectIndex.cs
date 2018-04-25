using System.Collections.Generic;
using System.Linq;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Viewmodels
{
    public class SubjectIndex
    {
        public List<Subject> Subjects { get; set; }

        public SubjectIndex()
        {
            using (var db = new SchoolContext())
            {
                Subjects = db.Subjects.ToList();
            }
        }
    }
}