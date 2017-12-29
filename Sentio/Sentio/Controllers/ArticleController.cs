using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleService;

        public ArticleController(IArticleServices articleService)
        {
            this.articleService = articleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ArticleDetails(int id)
        {
            var article = this.articleService.FindArticle(id);

            var viewModel = new ArticleViewModel()
            {
                Id = article.Id,
                Author = article.Author,
                Title = article.Title,
                Content = article.Content
            };

            return this.View(viewModel);
        }

        public ActionResult AllArticles()
        {
            var viewModel = this.articleService
                .ListAllArticles()
                .Select(a => new ArticleViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Author = a.Author,
                    Content = a.Content
                })
                .ToList();

            return this.View(viewModel);
        }
    }
}