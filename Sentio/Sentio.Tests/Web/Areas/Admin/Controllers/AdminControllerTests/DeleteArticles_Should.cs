using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Areas.Admin.Controllers;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Data.DataModels;
using Sentio.Models;
using Sentio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sentio.Tests.Web.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class DeleteArticles_Should
    {
        [TestMethod]
        public void ReturnDefaultView_WithCorrectViewModel()
        {
            // Arrange
            var userStore = new Mock<UserStore<ApplicationUser>>();
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(userStore.Object);
            var articleServiceMock = new Mock<IArticleServices>();
            var eventServiceMock = new Mock<IEventService>();

            //var author = "author";
            //var title = "title";
            //var content = "content";

            //var article = new Article()
            //{
            //    Author = author,
            //    Title = title,
            //    Content = content
            //};

            //var articles = new List<Article>()
            //{
            //    article
            //};

            //var viewModel = new ArticleViewModel()
            //{
            //    Author = author,
            //    Title = title,
            //    Content = content
            //};
            //var viewModels = new List<ArticleViewModel>()
            //{
            //    viewModel
            //};
            //var model = new ArticleContainerViewModel()
            //{
            //    CreateArticle = viewModel,
            //    Articles = viewModels
            //};

            //articleServiceMock.Setup(m => m.ListAllArticles()).Returns(articles);

            var controller = new AdminController(applicationUserManagerMock.Object, articleServiceMock.Object, eventServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.DeleteArticle())
                .ShouldRenderDefaultView()
                .WithModel<ArticleContainerViewModel>();
                //.WithModel(model);
        }
    }
}
