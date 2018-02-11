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
    public class GetEventShould
    {
        [TestMethod]
        public void ReturnCorrectEvent_WhenIdIsValid()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var eventSetMock = new Mock<DbSet<Event>>();

            var newEvent = new Event() { Id = 1 };
            var events = new List<Event>()
            {
                newEvent
            };

            eventSetMock.SetupData(events);
            dbContextMock.Setup(m => m.Events).Returns(eventSetMock.Object);

            EventService service = new EventService(dbContextMock.Object);

            //Act
            var result = service.GetEvent(1);

            //Assert
            Assert.AreSame(newEvent, result);
        }
    }
}
