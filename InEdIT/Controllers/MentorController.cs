using System;
using System.Web.Mvc;
using InEdITData;

namespace InEdIT.Controllers
{
    public class MentorController : Controller
    {
        // GET: Mentor
        public ActionResult Index(Guid mentorId)
        {
            object mentor = new MentorData().GetMentor(mentorId);
            return View(mentor);
        }
    }
}