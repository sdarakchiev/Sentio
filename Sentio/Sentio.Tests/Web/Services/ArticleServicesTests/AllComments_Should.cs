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
    public class AllComments_Should
    {
        [TestMethod]
        public void ReturnAllCommentsForArticle_WhenParameterIsCorrect()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();

            var articleId = 1;
            var comment = new Comment();
            var comments = new List<Comment>() { comment };
            var article = new Article()
            {
                Id = articleId,
                Comments = comments
            };
            var articles = new List<Article>() { article };

            var articlesSetMock = new Mock<DbSet<Article>>();
            articlesSetMock.SetupData(articles);

            dbContextMock.Setup(m => m.Articles).Returns(articlesSetMock.Object);

            var service = new ArticleServices(dbContextMock.Object);

            // Act
            var result = service.AllComments(articleId).ToList();

            // Assert
            CollectionAssert.AreEqual(comments, result);
        }
    }
}
