using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.DAL.Models;
using School.WEB.Models;

namespace School.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student();
            student.Firstname = "Jos";
            student.Lastname = "Mutter";

            using (var db = new SchoolContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }

            return View();
        }

        public IActionResult About()
        {
            using (var db = new SchoolContext())
            {
                var student = db.Students.SingleOrDefault(s => s.Firstname == "Jos" && s.Lastname == "Mutter");

                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
