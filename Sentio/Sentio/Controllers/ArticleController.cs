﻿using Bytes2you.Validation;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Data.ViewModels;
using Sentio.Services;
using System.Linq;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleService;

        public ArticleController(IArticleServices articleService)
        {
            Guard.WhenArgument(articleService, "articleService").IsNull().Throw();

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
                Content = article.Content,
                CommentViewModel = new ArticleCommentViewModel()
                {
                    ArticleId = article.Id
                },
                Comments = article.Comments,
                Likes = article.Likes
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

        public ActionResult Search(string query)
        {
            var articles = this.articleService.ListAllArticles();

            var result = articles
                .Select(a => new ArticleViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Author = a.Author,
                    Content = a.Content
                })
            .Where(a => a.Title.ToLower().Contains(query.ToLower()))
            .ToList();

            return this.PartialView("_SearchResults", result);
        }

        public ActionResult Comment(int articleId)
        {
            var comments = this.articleService.AllComments(articleId);

            var viewModel = comments
                .Select(c => new ArticleViewModel()
                {
                    Id = articleId,
                    CommentViewModel = new ArticleCommentViewModel()
                    {
                        ArticleId = c.ArticleId,
                        Content = c.Content
                    }
                })
            .ToList();

            return this.PartialView("_CommentPartial", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(ArticleViewModel viewModel)
        {
            this.articleService.AddComment(viewModel.CommentViewModel.ArticleId, viewModel.CommentViewModel.Content);

            return this.PartialView("_CommentPartial");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Like (int articleId)
        {
            var article = this.articleService.FindArticle(articleId);

            this.articleService.AddLike(articleId);

            var likes = this.articleService.AllArticleLikes(articleId);

            var viewModel = likes
                .Select(l => new ArticleViewModel
            {
                Id = articleId,
                Likes = likes
            })
            .ToList();

            return this.PartialView("_LikeArticle", viewModel);
        }

    }
}