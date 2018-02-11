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
    public class AddComment_Should
    {
        [TestMethod]
        public void CreateCommentForTheCorrectArticle_WhenParametersAreCorrect()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<Comment> comments = new List<Comment>();
            int articleId = 1;
            string content = "content";
            List<Article> articles = new List<Article>()
            {
                new Article()
                {
                    Id = articleId,
                    Comments = comments
                }
            };
            
            var articlesSetMock = new Mock<DbSet<Article>>().SetupData(articles);

            dbContextMock.SetupGet(m => m.Articles).Returns(articlesSetMock.Object);
            ArticleServices service = new ArticleServices(dbContextMock.Object);

            //Act
            service.AddComment(articleId, content);

            //Assert
            var article = dbContextMock.Object.Articles.First(a => a.Id == articleId);
            var comment = article.Comments.Single();

            Assert.AreEqual(articleId, comment.ArticleId);
            Assert.AreEqual(content, comment.Content);

            dbContextMock.Verify(m => m.SaveChanges(), Times.Once);

        }
    }
}
