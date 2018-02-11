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

namespace Sentio.Tests.Web.Services.EventServiceTests
{
    [TestClass]
    public class CreateEventShould
    {
        [TestMethod]
        public void CreateEventAndAddItToDb_WhenParametersAreCorrect()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<Event> events = new List<Event>();

            string eventName = "name";
            string eventDescription = "description";

            var eventSetMock = new Mock<DbSet<Event>>().SetupData(events);

            dbContextMock.SetupGet(m => m.Events).Returns(eventSetMock.Object);

            EventService service = new EventService(dbContextMock.Object);

            //Act
            service.CreateEvent(eventName, eventDescription);

            //Assert
            var newEvent = dbContextMock.Object.Events.Single();

            Assert.AreEqual(eventName, newEvent.Name);
            Assert.AreEqual(eventDescription, newEvent.Description);

            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
