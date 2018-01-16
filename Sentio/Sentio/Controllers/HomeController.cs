using Bytes2you.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Data.ViewModels;
using Sentio.Models;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IArticleServices articleService;
        private readonly IProfileServices profileService;

        public HomeController(ApplicationUserManager userManager, ApplicationDbContext dbContext, IArticleServices articleService)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(articleService, "articleService").IsNull().Throw();

            this.userManager = userManager;
            this.dbContext = dbContext;
            this.articleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [ChildActionOnly]
        [OutputCache(Duration = 300)]
        public ActionResult GetTopArticles()
        {
            var viewModel = this.articleService
                .GetTopArticles(3)
                .Select(a => new ArticleViewModel()
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                Author = a.Author
            })
            .ToList();
            
            return this.PartialView("_TopArticles", viewModel);
        }

        public async Task<ActionResult> About()
        {
           
            //this.dbContext.Roles.Add(new IdentityRole() { Name = "Admin" });
            // this.dbContext.SaveChanges();

            var user = await this.userManager.FindByNameAsync("eva@sentio.bg");
            await this.userManager.AddToRoleAsync(user.Id, "Admin");
            this.dbContext.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

       
    }
}