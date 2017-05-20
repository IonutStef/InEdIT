using System;
using System.Collections.Generic;
using System.Linq;
using InEdITData.Data;

namespace InEdITData
{
    public class MentorData
    {
        public Mentor GetMentor(Guid mentorId)
        {
            using (var context = new InEdItModel())
            {
                return context.Mentors.FirstOrDefault(m => m.MentorId == mentorId);
            }
        }

        public IList<Mentor>GetMentors()
        {
            // Get Mentor Data from Database
            using (var context = new InEdItModel())
            {
                return context.Mentors.ToList();
            }
        }

        public void AddMentor(Mentor mentor)
        {
            // Add Mentor to database
            using (var context = new InEdItModel())
            {
                context.Mentors.Add(mentor);
                context.SaveChanges();
            }
        }
    }
}
