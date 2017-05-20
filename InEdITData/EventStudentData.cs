using System;
using System.Linq;
using InEdITData.Data;

namespace InEdITData
{
    public class EventStudentData
    {
        public void SubscribeToEvent(Guid studentId, Guid eventId)
        {
            using (var context = new InEdItModel())
            {
                var eventStudent = new EventStudent
                {
                    ApplyDate = DateTime.Now,
                    EventId = eventId,
                    StudentId = studentId
                };

                context.EventStudents.Add(eventStudent);
                context.SaveChanges();
            }
        }

        public void UnsubscribeFromEvent(Guid studentId, Guid eventId)
        {
            using (var context = new InEdItModel())
            {
                var eventStudent =
                    context.EventStudents.AsNoTracking()
                        .FirstOrDefault(es => es.StudentId == studentId && es.EventId == eventId);

                if (eventStudent == null) return;

                context.EventStudents.Remove(eventStudent);
                context.SaveChanges();
            }
        }
        

        public bool GetApplicationForEvent(Guid studentId, Guid eventId)
        {
            using (var context = new InEdItModel())
            {
                return context.EventStudents.Any(es => es.StudentId == studentId && es.EventId == eventId);
            }
        }
    }
}
