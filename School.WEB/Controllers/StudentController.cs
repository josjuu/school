using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.DAL.Models;
using School.WEB.Viewmodels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WEB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(new StudentIndex());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add", new StudentAdd());
        }

        [HttpPost]
        public IActionResult Add(StudentAdd studentAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", studentAdd);
            }

            using (var db = new SchoolContext())
            {
                var student = new Student
                {
                    Firstname = studentAdd.Firstname,
                    Lastname = studentAdd.Lastname
                };

                db.Students.Add(student);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index", "Student");
        }

        [HttpGet("[controller]/Edit/{id}")]
        public IActionResult Update(int id)
        {
            using (var db = new SchoolContext())
            {
                var student = db.Students.SingleOrDefault(s => s.Id == id);

                if (student == null)
                {
                    return RedirectToActionPermanent("Index");
                }
            }

            return View("Update", new StudentUpdate(id));
        }

        [HttpPost("[controller]/Edit/{id}")]
        public IActionResult Update(StudentUpdate studentUpdate)
        {
            if (studentUpdate == null)
            {
                return RedirectToActionPermanent("Index");
            }

            if (!ModelState.IsValid)
            {
                return View("Update", studentUpdate);
            }

            using (var db = new SchoolContext())
            {
                var student = db.Students.SingleOrDefault(s => s.Id == studentUpdate.Id);

                if (student == null)
                {
                    return RedirectToActionPermanent("Index");
                }

                student.Firstname = studentUpdate.Firstname;
                student.Lastname = studentUpdate.Lastname;

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

            return View("Index", new StudentIndex());
        }
    }
}
