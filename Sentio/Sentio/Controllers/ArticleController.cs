using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sentio.Data.ViewModels;
using Sentio.Data.DataModels;
using Bytes2you.Validation;
using Sentio.Services;

namespace Sentio.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices articleService;
        private readonly IProfileServices profileService;

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
            .Where(a => a.Title.ToLower() == query.ToLower())
            .ToList();

            return this.PartialView("_SearchResults", result);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Comment(ArticleViewModel viewModel, string content)
        //{
        //        var userId = this.User.Identity.GetUserId();
        //        this.articleService.AddComment(userId, viewModel.CommentContent, viewModel.Id);


        //    return this.PartialView("_CommentPartial", viewModel);
        //}

        public ActionResult Comment(int articleId)
        {
            var viewModel = new ArticleViewModel();
            viewModel.Id = articleId;

            return this.PartialView("_CommentPartial", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Comment(Comment comment)
        {
            this.articleService.AddComment(comment.UserId, comment.Content, comment.ArticleId);

            return RedirectToAction("ArticleDetails", new { id = comment.ArticleId });
        }

       

        //[HttpPost]
        //public ActionResult Comment(ArticleCommentViewModel viewModel)
        //{
        //    this.articleService.AddComment(viewModel.UserId, viewModel.Content, viewModel.ArticleId);

        //    return this.PartialView("_CommentContent", viewModel);
        //}

        //[HttpPost]
        //public ActionResult Comment(string content)
        //{
        //    var comments = new List<string>();
        //    comments.Add(content);
        //    //return this.Content(content);
        //    return this.PartialView("_CommentContent", comments);
        //}
    }
}