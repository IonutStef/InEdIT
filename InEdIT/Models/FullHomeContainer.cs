using System.Collections.Generic;
using InEdITData.Data;

namespace InEdIT.Models
{
    public class FullHomeContainer
    {
        public string Description { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Mentor> Mentors { get; set; }
    }
}