using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Data.DataModels;
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

        public AdminController(ApplicationUserManager userManager, IArticleServices articleService)
        {
            this.userManager = userManager;
            this.articleService = articleService;
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
    }
}