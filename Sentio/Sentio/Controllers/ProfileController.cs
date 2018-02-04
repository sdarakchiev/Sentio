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
    public class ProfileController : Controller
    {
        private readonly IProfileServices profileService;
        public ProfileController(IProfileServices profileService)
        {
           
            Guard.WhenArgument(profileService, "profileService").IsNull().Throw();

           
            this.profileService = profileService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            var userName = HttpContext.User.Identity.Name;

            var viewProfile = new ProfileViewModel()
            {
                Username = userName
            };
            return this.View(viewProfile);
        }

        public ActionResult UserEvents()
        {
            var userName = HttpContext.User.Identity.Name;

            this.profileService.EventsForUser(userName);

            var viewModel = this.profileService
                .EventsForUser(userName)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description
                })
                .ToList();

            return this.PartialView(viewModel);
        }

        public ActionResult JoinEvent(EventViewModel viewModel)
        {
            var userName = this.User.Identity.Name;

            if(this.ModelState.IsValid)
            {
                this.profileService.JoinEvent(viewModel.Id, userName);

                return this.RedirectToAction("AllEvents", "Event");
            }
            return this.PartialView("_JoinEvent");
        }
    }
}