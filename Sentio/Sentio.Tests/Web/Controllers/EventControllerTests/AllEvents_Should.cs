using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Controllers;
using Sentio.Data.DataModels;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sentio.Tests.Web.Controllers.EventControllerTests
{
    [TestClass]
    public class AllEvents_Should
    {
        [TestMethod]
        public void ReturnDefaultView_WithCorrectModel()
        {
            // Arrange
            var eventServiceMock = new Mock<IEventService>();

            List<Event> events = new List<Event>()
            {
                new Event() {Id = 1}
            };

            var eventsSetMock = new Mock<DbSet<Event>>().SetupData(events);
            eventServiceMock.Setup(m => m.AllEvents()).Returns(eventsSetMock.Object);

            //var model = articles.Select(a => new ArticleViewModel() { Id = 1 });
            var controller = new EventController(eventServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllEvents())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<EventViewModel>>(m => m.First(a => a.Id == 1));
        }
    }
}
