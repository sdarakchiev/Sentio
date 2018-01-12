using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Controllers;
using Sentio.Data.DataModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using EntityFramework.Testing;

namespace Sentio.Tests.Web.Controllers.ArticleControllerTests
{
    [TestClass]
    public class AllArticles_Should
    {
        [TestMethod]
        public void ReturnDefaultView_WithListOfModels()
        {
            // Arrange
            var articleServiceMock = new Mock<IArticleServices>();

            List<Article> articles = new List<Article>()
            {
                new Article() {Id = 1}
            };

            var articlesSetMock = new Mock<DbSet<Article>>().SetupData(articles);
            articleServiceMock.Setup(m => m.ListAllArticles()).Returns(articlesSetMock.Object);

            //var model = articles.Select(a => new ArticleViewModel() { Id = 1 });
            var controller = new ArticleController(articleServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllArticles())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ArticleViewModel>>(m => m.First(a => a.Id == 1));
        }
    }
}
