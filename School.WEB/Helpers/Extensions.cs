using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.DAL.Models;

namespace School.WEB.Helpers
{
    public static class Extensions
    {
        public static string GetFullname(this Student student)
        {
            return $"{student.Firstname} {student.Lastname}";
        }
    }
}
