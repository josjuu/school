using System.Linq;
using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.DAL.Models;
using School.WEB.Viewmodels;

namespace School.WEB.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new TeacherIndex());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add", new TeacherAdd());
        }

        [HttpPost]
        public IActionResult Add(TeacherAdd teacherAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", teacherAdd);
            }

            using (var db = new SchoolContext())
            {
                var teacher = new Teacher
                {
                    Firstname = teacherAdd.Firstname,
                    Lastname = teacherAdd.Lastname
                };

                db.Teachers.Add(teacher);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index", "Teacher");
        }

        [HttpGet("[controller]/Edit/{id}")]
        public IActionResult Update(int id)
        {
            using (var db = new SchoolContext())
            {
                var teacher = db.Teachers.SingleOrDefault(t => t.Id == id);

                if (teacher == null)
                {
                    return RedirectToActionPermanent("Index");
                }
            }

            return View("Update", new TeacherUpdate(id));
        }

        [HttpPost("[controller]/Edit/{id}")]
        public IActionResult Update(TeacherUpdate teacherUpdate)
        {
            if (teacherUpdate == null)
            {
                return RedirectToActionPermanent("Index");
            }

            if (!ModelState.IsValid)
            {
                return View("Update", teacherUpdate);
            }

            using (var db = new SchoolContext())
            {
                var teacher = db.Teachers.SingleOrDefault(t => t.Id == teacherUpdate.Id);

                if (teacher == null)
                {
                    return RedirectToActionPermanent("Index");
                }

                teacher.Firstname = teacherUpdate.Firstname;
                teacher.Lastname = teacherUpdate.Lastname;

                db.Teachers.Update(teacher);
                db.SaveChanges();

                return RedirectToActionPermanent("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var teacher = db.Teachers.SingleOrDefault(s => s.Id == id);

                if (teacher == null || id <= 0)
                {
                    return RedirectToActionPermanent("Index");
                }

                db.Teachers.Remove(teacher);
                db.SaveChanges();

                return View("Index", new TeacherIndex());
            }
        }
    }
}