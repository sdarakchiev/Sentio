using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using Sentio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

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

            var model = new List<ArticleViewModel>();
            var controller = new ArticleController(articleServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllArticles())
                .ShouldRenderDefaultView().WithModel<IEnumerable<ArticleViewModel>>();
        }
    }
}
