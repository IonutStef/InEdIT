using System;
using System.Collections.Generic;
using System.Linq;
using InEdITData.Data;

namespace InEdITData
{
    public class EventData
    {
        public IList<Event> GetEvents()
        {
            // Get all Events
            using (var context = new InEdItModel())
            {
                return context.Events.ToList();
            }
        }

        public IList<Event> GetEventsByStudentId(Guid studentId)
        {
            // Get all Events
            using (var context = new InEdItModel())
            {
                var eventsIds =
                    context.EventStudents.Where(es => es.StudentId == studentId).Select(e => e.EventId).ToList();

                var events = context.Events.Where(e => eventsIds.Contains(e.EventId)).ToList();

                return events;
            }
        }

        public IList<Event> GetAvailableEventsForStudentId(Guid studentId)
        {
            // Get all Events
            using (var context = new InEdItModel())
            {
                var eventsIds =
                    context.EventStudents.Where(es => es.StudentId != studentId).Select(e => e.EventId).ToList();

                var events = context.Events.Where(e => eventsIds.Contains(e.EventId)).ToList();

                return events;
            }
        }

        public IList<Event> GetEventsByMentorId(Guid mentorId)
        {
            // Get all Events
            using (var context = new InEdItModel())
            {
                var events = context.Events.Where(e => e.MentorId == mentorId).ToList();

                return events;
            }
        }

        public Event GetEvent(Guid eventId)
        {
            // Get Event by Id
            using (var context = new InEdItModel())
            {
                return context.Events.FirstOrDefault(e => e.EventId == eventId);
            }
        }

        public void AddEvent(Event eventEnt)
        {
            eventEnt.CreationDateTime = DateTime.Now;

            using (var context = new InEdItModel())
            {
                context.Events.Add(eventEnt);
                context.SaveChanges();
            }
        }
    }
}
