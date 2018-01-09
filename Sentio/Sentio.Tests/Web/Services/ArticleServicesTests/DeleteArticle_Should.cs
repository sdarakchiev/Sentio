using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Areas.Admin.Services;
using Sentio.Data.DataModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Tests.Web.Services.ArticleServicesTests
{
    [TestClass]
    public class DeleteArticle_Should
    {
        [TestMethod]
        public void RemoveArticleFromatabase_WhenParameterIsCorrect()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var article = new Article();
            List<Article> articles = new List<Article>() { article };
            var articlesSetMock = new Mock<DbSet<Article>>().SetupData(articles);

            dbContextMock.Setup(m => m.Articles).Returns(articlesSetMock.Object);

            var service = new ArticleServices(dbContextMock.Object);

            // Act
            service.DeleteArticle(article);

            // Assert
            Assert.AreEqual(0, dbContextMock.Object.Articles.Count());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var service = new ArticleServices(dbContextMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.DeleteArticle(null));
        }
    }
}
