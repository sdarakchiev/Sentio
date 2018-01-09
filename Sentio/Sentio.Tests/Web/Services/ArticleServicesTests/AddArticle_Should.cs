using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sentio.Data.DataModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Testing;
using Sentio.Areas.Admin.Services;

namespace Sentio.Tests.Web.Services.ArticleServicesTests
{
    [TestClass]
    public class AddArticle_Should
    {
        [TestMethod]
        public void CreateArticleAndAddItToDb_WhenParametersAreCorrect()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<Article> articles = new List<Article>();

            string articlieAuthor = "author";
            string articleTitle = "title";
            string articleContent = "content";

            var articlesSetMock = new Mock<DbSet<Article>>().SetupData(articles);


            dbContextMock.SetupGet(m => m.Articles).Returns(articlesSetMock.Object);

            ArticleServices service = new ArticleServices(dbContextMock.Object);

            // Act
            service.AddArticle(articlieAuthor, articleTitle, articleContent);

            // Assert
            var article = dbContextMock.Object.Articles.Single();

            Assert.AreEqual(articleTitle, article.Title);
            Assert.AreEqual(articleContent, article.Content);
            Assert.AreEqual(articlieAuthor, article.Author);

            dbContextMock.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
