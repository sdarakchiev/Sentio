using Microsoft.AspNet.Identity.EntityFramework;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Models;
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

        public HomeController(ApplicationUserManager userManager, ApplicationDbContext dbContext, IArticleServices articleService)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.articleService = articleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTopArticles()
        {
            var viewModel = this.articleService
                .GetTopArticles(3)
                .Select(a => new ArticleViewModel()
            {
                Title = a.Title,
                Content = a.Content,
                Author = a.Author
            })
            .ToList();
            
            return this.PartialView("_TopArticles", viewModel);
        }

        public ActionResult About()
        {
           
            //this.dbContext.Roles.Add(new IdentityRole() { Name = "Admin" });
            // this.dbContext.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}