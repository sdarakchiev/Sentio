using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Controllers;
using Sentio.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sentio.Tests.Web.Controllers.ArticleControllerTests
{
    [TestClass]
    public class ArticleDetails_Should
    {
        [TestMethod]
        public void ReturnDefaultView_WithCorrectViewModel()
        {
            //Arrange
            var articleServiceMock = new Mock<IArticleServices>();
            int articleId = 1;
            string author = "author";
            string title = "title";
            string content = "content";
            var article = new Article()
            {
                Id = articleId,
                Author = author,
                Title = title,
                Content = content
            };

            articleServiceMock.Setup(m => m.FindArticle(articleId)).Returns(article);
            var controller = new ArticleController(articleServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.ArticleDetails(articleId))
                .ShouldRenderDefaultView()
                .WithModel<ArticleViewModel>(m => m.Id == articleId);
        }
    }
}
