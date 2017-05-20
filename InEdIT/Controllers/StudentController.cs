using System;
using System.Web.Mvc;
using InEdIT.Models;
using InEdITData;

namespace InEdIT.Controllers
{
    public class StudentController : Controller
    {
        private StudentData StudentData { get; set; }
        private EventData EventData { get; set; }

        public StudentController()
        {
            //StudentData = new StudentData();
            //EventData = new EventData();
        }

        // GET: Student
        public ActionResult Index(Guid? studentId)
        {
            if (!studentId.HasValue)
            {
                return View();
            }

            var student = StudentData.GetStudent(studentId.Value);
            var appliedEvents = EventData.GetEventsByStudentId(studentId.Value);
            var availableEvents = EventData.GetAvailableEventsForStudentId(studentId.Value);

            var fullStudentDetails = new FullStudentContainer
            {
                AppliedEvents = appliedEvents,
                AvailableEvents = availableEvents,
                Student = student
            };

            return View(fullStudentDetails);
        }
    }
}