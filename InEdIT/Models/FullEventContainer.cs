using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InEdITData.Data;

namespace InEdIT.Models
{
    public class FullEventContainer
    {
        public Event Event { get; set; }
        public Mentor Mentor { get; set; }
        public bool Applied { get; set; }
    }
}