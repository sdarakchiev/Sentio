using Bytes2you.Validation;
using Sentio.Data.DataModels;
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

        public IEnumerable<Event> EventsForUser(string userName)
        {
            return this.dbContext.Users.First(u => u.UserName == userName).Events.ToList();
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