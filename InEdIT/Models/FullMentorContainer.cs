using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InEdITData.Data;

namespace InEdIT.Models
{
    public class FullMentorContainer
    {
        public Mentor Mentor { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}