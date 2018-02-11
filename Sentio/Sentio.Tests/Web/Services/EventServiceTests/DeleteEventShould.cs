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
    public class DeleteEventShould
    {
        [TestMethod]
        public void RemoveEventFromatabase_WhenParameterIsCorrect()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var newEvent = new Event();
            List<Event> events = new List<Event>() { newEvent };
            var eventsSetMock = new Mock<DbSet<Event>>().SetupData(events);

            dbContextMock.Setup(m => m.Events).Returns(eventsSetMock.Object);

            var service = new EventService(dbContextMock.Object);

            // Act
            service.DeleteEvent(newEvent);

            // Assert
            Assert.AreEqual(0, dbContextMock.Object.Events.Count());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var service = new EventService(dbContextMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.DeleteEvent(null));
        }
    }
}
