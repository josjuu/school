using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.DAL;
using School.DAL.Models;

namespace School.WEB.Viewmodels
{
    public class StudentIndex
    {
        public List<Student> Students { get; }

        public StudentIndex()
        {
            using (var db = new SchoolContext())
            {
                Students = db.Students.ToList();
            }
        }
    }
}
