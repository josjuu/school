using Microsoft.AspNetCore.Mvc;
using School.WEB.Viewmodels;

namespace School.WEB.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new SubjectIndex());
        }
    }
}