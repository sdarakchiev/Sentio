using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Controllers;
using Sentio.Data.DataModels;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sentio.Tests.Web.Controllers.EventControllerTests
{
    [TestClass]
    public class EventDetails_Should
    {
        [TestMethod]
        public void ReturnDefaultView_WithCorrectModel()
        {
            //Arrange
            var eventServiceMock = new Mock<IEventService>();
            int eventId = 1;
            string name = "name";
            string desription = "description";
            var newEvent = new Event()
            {
                Id = eventId,
                Name = name,
                Description = desription
            };

            eventServiceMock.Setup(m => m.GetEvent(eventId)).Returns(newEvent);
            var controller = new EventController(eventServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.EventDetails(eventId))
                .ShouldRenderDefaultView()
                .WithModel<EventViewModel>(m => m.Id == eventId);
        }
    }
}
