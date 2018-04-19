using System.Linq;
using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.DAL.Models;
using School.WEB.Viewmodels;

namespace School.WEB.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new SubjectIndex());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add", new SubjectAdd());
        }

        [HttpPost]
        public IActionResult Add(SubjectAdd subjectAdd)
        {
            if (!ModelState.IsValid) return View("Add", subjectAdd);

            using (var db = new SchoolContext())
            {
                var subject = new Subject
                {
                    SubjectName = subjectAdd.Name,
                    TeacherId = subjectAdd.TeacherId
                };

                db.Subjects.Add(subject);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index", "Subject");
        }

        [HttpGet("[controller]/Edit/{id}")]
        public IActionResult Update(int id)
        {
            using (var db = new SchoolContext())
            {
                var subjects = db.Subjects.SingleOrDefault(s => s.Id == id);

                if (subjects == null)
                {
                    return RedirectToActionPermanent("Index");
                }
            }

            return View("Update", new SubjectUpdate(id));
        }

        [HttpPost("[controller]/Edit/{id}")]
        public IActionResult Update(SubjectUpdate subjectUpdate)
        {
            if (subjectUpdate == null)
            {
                return RedirectToActionPermanent("Index");
            }

            if (!ModelState.IsValid)
            {
                return View("Update", subjectUpdate);
            }

            using (var db = new SchoolContext())
            {
                var subject = db.Subjects.SingleOrDefault(s => s.Id == subjectUpdate.Id);

                if (subject == null)
                {
                    return RedirectToActionPermanent("Index");
                }

                subject.Id = subjectUpdate.Id;
                subject.SubjectName = subjectUpdate.Name;
                subject.TeacherId = subjectUpdate.TeacherId;

                db.Subjects.Update(subject);
                db.SaveChanges();

                return RedirectToActionPermanent("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var subject = db.Subjects.SingleOrDefault(s => s.Id == id);

                if (subject == null || id <= 0)
                {
                    return RedirectToActionPermanent("Index");
                }

                db.Subjects.Remove(subject);
                db.SaveChanges();

                return View("Index", new SubjectIndex());
            }
        }
    }
}