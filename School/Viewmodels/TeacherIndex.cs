using System.Collections.Generic;
using System.Linq;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Viewmodels
{
    public class TeacherIndex
    {
        public List<Teacher> Teachers { get; }

        public TeacherIndex()
        {
            using (var db = new SchoolContext())
            {
                Teachers = db.Teachers.ToList();
            }
        }
    }
}