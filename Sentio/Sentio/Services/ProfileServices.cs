using Bytes2you.Validation;
using Sentio.Data.DataModels;
using Sentio.Data.Models;
using Sentio.Data.ViewModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly ApplicationDbContext dbContext;

        public ProfileServices(ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public IEnumerable<EventModel> EventsForUser(string userName)
        {
            var user = this.dbContext.Users.First(u => u.UserName == userName);

            var events = this.dbContext
                .Events
                .Where(e => e.Users.First().Id == user.Id)
                .Select(e => new EventModel
                {
                    Name = e.Name,
                    Description = e.Description
                })
                .ToList();

            return events;
        }

        public void JoinEvent(int eventId, string userName)
        {
            Event newEvent = this.dbContext.Events.First(e => e.Id == eventId);

            var user = this.dbContext.Users.First(u => u.UserName == userName);
            user.Events.Add(newEvent);
            this.dbContext.SaveChanges();
        }

    }
}