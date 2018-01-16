using Bytes2you.Validation;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Data.DataModels;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly IArticleServices articleService;
        private readonly IEventService eventService;

        public AdminController(ApplicationUserManager userManager, IArticleServices articleService, IEventService eventService)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(articleService, "articleService").IsNull().Throw();
            Guard.WhenArgument(eventService, "eventService").IsNull().Throw();

            this.userManager = userManager;
            this.articleService = articleService;
            this.eventService = eventService;
        }
        // GET: Admin/Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var articles = this.articleService
                .ListAllArticles()
                .Select(a =>
                new ArticleViewModel
                {
                    Id = a.Id,
                    Author = a.Author,
                    Title = a.Title
                })
                .ToList();

            ArticleContainerViewModel viewModel = new ArticleContainerViewModel()
            {
                CreateArticle = new ArticleViewModel(),
                Articles = articles
            };

            return View(viewModel);

            //return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ArticleContainerViewModel viewModel)
        {
           
            if (this.ModelState.IsValid)
            {
                this.articleService.AddArticle(viewModel.CreateArticle.Author, viewModel.CreateArticle.Title, viewModel.CreateArticle.Content);

                return this.RedirectToAction("Index");
            }

            return this.View(viewModel);
        }

        public ActionResult DeleteArticle()
        {
            var articles = this.articleService
                .ListAllArticles()
                .Select(a =>
                new ArticleViewModel
                {
                    Id = a.Id,
                    Author = a.Author,
                    Title = a.Title
                })
                .ToList();

            ArticleContainerViewModel viewModel = new ArticleContainerViewModel()
            {
                CreateArticle = new ArticleViewModel(),
                Articles = articles
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteArticle")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArticle (int id)
        {
            var article = this.articleService.FindArticle(id);
            
            this.articleService.DeleteArticle(article);

            return this.RedirectToAction("Index");
        }

        public ActionResult CreateEvent()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(EventViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.eventService.CreateEvent(viewModel.Name, viewModel.Description);

                return this.RedirectToAction("CreateEvent");
            }

            return this.View(viewModel);
        }
    }
}