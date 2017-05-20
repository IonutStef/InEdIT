using System;
using System.Web.Mvc;
using InEdIT.Models;
using InEdITData;
using InEdITData.Data;

namespace InEdIT.Controllers
{
    public class EventController : Controller
    {
        private EventData EventData { get; set; }
        private MentorData MentorData { get; set; }
        private EventStudentData EventStudentData { get; set; }

        public EventController()
        {
            //EventData = new EventData();
            //MentorData = new MentorData();
            //EventStudentData = new EventStudentData();
        }

        // GET: Event
        public ActionResult Index(Guid? eventId, Guid? studentId)
        {
            Event eventEnt;
            Mentor mentor;
            FullEventContainer fullEventDetails;
            if (!eventId.HasValue || !studentId.HasValue)
            {
                eventEnt = new Event
                {
                    AvailableSeats = 30,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui autem de summo bono dissentit de tota philosophiae ratione dissentit. Respondent extrema primis, media utrisque, omnia omnibus. Nummus in Croesi divitiis obscuratur, pars est tamen divitiarum. Ego vero isti, inquam, permitto. Duo Reges: constructio interrete. Quonam, inquit, modo?\nQuae similitudo in genere etiam humano apparet.Non enim,\nsi omnia non sequebatur, idcirco non erat ortus illinc.\n",
                    Name = "Event Name",
                    ScheduledDate = DateTime.Now.AddMonths(6),
                    Place = "Faculty of Computer Science"
                };
                mentor = new Mentor
                {
                    Description = "Description",
                    Ocupation = "Developer",
                    Picture = "~/content/Images/Home/mentor.jpg"
                };

                fullEventDetails = new FullEventContainer
                {
                    Applied = false,
                    Event = eventEnt, 
                    Mentor = mentor
                };

                return View(fullEventDetails);
            }

            eventEnt = EventData.GetEvent(eventId.Value);
            mentor = MentorData.GetMentor(eventEnt.MentorId);
            var appliedToEvent = EventStudentData.GetApplicationForEvent(studentId.Value, eventId.Value);

            fullEventDetails = new FullEventContainer
            {
                Event = eventEnt,
                Mentor = mentor,
                Applied = appliedToEvent
            };

            return View(fullEventDetails);
        }


        public ActionResult SubscribeToEvent(Guid studentId, Guid eventId)
        {
            //EventStudentData.SubscribeToEvent(studentId, eventId);

            return View("Index");
        }
    }
}