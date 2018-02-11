using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Data.DataModels;
using Sentio.Models;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Tests.Web.Services.ProfileServicesTests
{
    [TestClass]
    public class JoinEvent_Should
    {
        [TestMethod]
        public void AddEventToCorrectUser_WhenParametersAreCorrect()
        {
            var dbContextMock = new Mock<ApplicationDbContext>();
            int eventId = 1;
            string userName = "Ivan";
            var newEvent = new Event() { Id = eventId };
            var events = new List<Event>() { newEvent };

            var user = new ApplicationUser()
            {
                UserName = userName,
                Events = events
            };
            var users = new List<ApplicationUser>() { user };

            var userSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
            var eventSetMock = new Mock<DbSet<Event>>().SetupData(events);

            dbContextMock.Setup(m => m.Users).Returns(userSetMock.Object);
            dbContextMock.Setup(m => m.Events).Returns(eventSetMock.Object);

            var service = new ProfileServices(dbContextMock.Object);

            //Act
            service.JoinEvent(eventId, userName);

            //Assert
            var dbUser = dbContextMock.Object.Users.First(u => u.UserName == userName);
            var userEvent = dbUser.Events.First(e => e.Id == eventId);

            Assert.AreEqual(eventId, userEvent.Id);

            dbContextMock.Verify(m => m.SaveChanges(), Times.Once);

        }
    }
}
