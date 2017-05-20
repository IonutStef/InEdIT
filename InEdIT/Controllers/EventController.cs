using System;
using System.Web.Mvc;
using InEdIT.Models;
using InEdITData;

namespace InEdIT.Controllers
{
    public class EventController : Controller
    {
        private EventData EventData { get; set; }
        private MentorData MentorData { get; set; }
        private EventStudentData EventStudentData { get; set; }

        public EventController()
        {
            EventData = new EventData();
            MentorData = new MentorData();
            EventStudentData = new EventStudentData();
        }

        // GET: Event
        public ActionResult Index(Guid? eventId, Guid? studentId)
        {
            if (!eventId.HasValue || !studentId.HasValue)
            {
                return View();
            }

            var eventEnt = EventData.GetEvent(eventId.Value);
            var mentor = MentorData.GetMentor(eventEnt.MentorId);
            var appliedToEvent = EventStudentData.GetApplicationForEvent(studentId.Value, eventId.Value);

            var fullEventDetails = new FullEventContainer
            {
                Event = eventEnt,
                Mentor = mentor,
                Applied = appliedToEvent
            };

            return View(fullEventDetails);
        }


        public ActionResult SubscribeToEvent(Guid studentId, Guid eventId)
        {
            EventStudentData.SubscribeToEvent(studentId, eventId);

            return View("Index");
        }
    }
}