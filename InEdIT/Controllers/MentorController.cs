using System;
using System.Web.Mvc;
using InEdIT.Models;
using InEdITData;
using InEdITData.Data;

namespace InEdIT.Controllers
{
    public class MentorController : Controller
    {
        private MentorData MentorData { get; set; }
        private EventData EventData { get; set; }

        public MentorController()
        {
            //MentorData = new MentorData();
            //EventData = new EventData();
        }

        // GET: Mentor
        public ActionResult Index(Guid? mentorId)
        {
            if (!mentorId.HasValue)
            {
                
                return View();
            }

            var mentor = MentorData.GetMentor(mentorId.Value);
            var events = EventData.GetEventsByMentorId(mentorId.Value);
            var fullMentorDetails = new FullMentorContainer
            {
                Events = events,
                Mentor = mentor
            };

            return View(fullMentorDetails);
        }

        public ActionResult Mentors()
        {
            return View();
        }
    }
}