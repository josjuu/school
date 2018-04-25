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
            if (!ModelState.IsValid)
            {
                return View("Add", subjectAdd);
            }

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
    }
}