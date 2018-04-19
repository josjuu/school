using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.DAL.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WEB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string firstname, string lastname)
        {
            var student = new Student();
            student.Firstname = firstname;
            student.Lastname = lastname;

            using (var db = new SchoolContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index");
        }

        [HttpGet("[controller]/Edit/{id}")]
        public IActionResult Update(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost("[controller]/Edit/{id}")]
        public IActionResult Update(int id, string firstname, string lastname)
        {
            using (var db = new SchoolContext())
            {
                var student = db.Students.SingleOrDefault(s => s.Id == id);

                if (student == null)
                {
                    return RedirectToActionPermanent("Index");
                }

                student.Firstname = firstname;
                student.Lastname = lastname;

                db.Students.Update(student);
                db.SaveChanges();

                return RedirectToActionPermanent("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var student = db.Students.SingleOrDefault(s => s.Id == id);

                if (student == null || id <= 0)
                {
                    return RedirectToActionPermanent("Index");
                }

                db.Students.Remove(student);
                db.SaveChanges();
            }

            return View("Index");
        }
    }
}
