using Bytes2you.Validation;
using Sentio.Data.DataModels;
using Sentio.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sentio.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext dbContext;

        public EventService(ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public void CreateEvent(string name, string description)
        {
            Event newEvent = new Event()
            {
                Name = name,
                Description = description
            };

            this.dbContext.Events.Add(newEvent);
            this.dbContext.SaveChanges();
        }

        public Event GetEvent (int id)
        {
            var theEvent = this.dbContext.Events.FirstOrDefault(e => e.Id == id);

            return theEvent;
        }

        public IEnumerable<Event> AllEvents()
        {
            return this.dbContext.Events.ToList();
        }

        public void DeleteEvent (Event theEvent)
        {
            Guard.WhenArgument(theEvent, "event").IsNull().Throw();

            this.dbContext.Events.Remove(theEvent);
            this.dbContext.SaveChanges();
        }
    }
}