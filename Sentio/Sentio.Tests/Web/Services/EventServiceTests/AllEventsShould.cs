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
    public class AllEventsShould
    {
        [TestMethod]
        public void ReturnAllEvents()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var newEvent = new Event();
            var events = new List<Event>() { newEvent };

            var eventsSetMock = new Mock<DbSet<Event>>();
            eventsSetMock.SetupData(events);

            dbContextMock.Setup(m => m.Events).Returns(eventsSetMock.Object);

            var service = new EventService(dbContextMock.Object);

            // Act
            var result = service.AllEvents().ToList();

            // Assert
            CollectionAssert.AreEqual(events, result);
        }
        
    }
}
