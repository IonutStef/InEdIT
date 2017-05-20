using System;
using System.Web.Mvc;
using InEdITData;

namespace InEdIT.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(Guid studentId)
        {
            object student = new StudentData().GetStudent(studentId);
            return View(student);
        }
    }
}