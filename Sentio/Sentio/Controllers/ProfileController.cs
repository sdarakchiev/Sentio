using Bytes2you.Validation;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System.Linq;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    [Authorize]
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

        public ActionResult UserProfile()
        {
            var userName = this.User.Identity.Name;

            var events = this.profileService
                .EventsForUser(userName)
                .Select(e => new EventViewModel()
                {
                    Name = e.Name,
                    Description = e.Description
                })
                .ToList();

            var viewProfile = new ProfileViewModel()
            {
                Username = userName,
                Events = events
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
                    Name = e.Name,
                    Description = e.Description
                })
                .ToList();

            return this.PartialView(viewModel);
        }

        [ValidateAntiForgeryToken]
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