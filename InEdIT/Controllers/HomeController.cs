using System.Web.Mvc;
using InEdIT.Models;
using InEdITData;

namespace InEdIT.Controllers
{
    public class HomeController : Controller
    {
        private MentorData _mentorData { get; set; }
        private EventData _eventData { get; set; }

        public HomeController()
        {
           // _mentorData = new MentorData();
            //_eventData = new EventData();
        }


        public ActionResult Index()
        {
            //var events = _eventData.GetEvents();
            //var mentors = _mentorData.GetMentors();
            
            var homeDetails = new FullHomeContainer
            {
                Description = "Description",
                //Events = events,
                //Mentors = mentors
            };

            return View(homeDetails);
        }

        public ActionResult About()
        {
            ViewBag.Message = "InEdIT";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }
    }
}