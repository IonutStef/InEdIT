using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InEdITData.Data;

namespace InEdIT.Models
{
    public class FullStudentContainer
    {
        public Student Student { get; set; }
        public IEnumerable<Event> AppliedEvents { get; set; }
        public IEnumerable<Event> AvailableEvents { get; set; }
    }
}