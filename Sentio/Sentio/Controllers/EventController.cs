using Bytes2you.Validation;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            Guard.WhenArgument(eventService, "eventService").IsNull().Throw();

            this.eventService = eventService;
        }

        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllEvents()
        {
            var viewModel = this.eventService
                .AllEvents()
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                   Name = e.Name,
                   Description = e.Description
                })
                .ToList();

            return this.View(viewModel);
        }

        public ActionResult EventDetails(int id)
        {
            var newEvent = this.eventService.GetEvent(id);

            var viewModel = new EventViewModel()
            {
                Id = newEvent.Id,
                Name = newEvent.Name,
                Description = newEvent.Description
            };

            return this.View(viewModel);
        }
    }
}