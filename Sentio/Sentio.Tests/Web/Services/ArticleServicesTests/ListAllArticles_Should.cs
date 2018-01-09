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
    public class ListAllArticles_Should
    {
        [TestMethod]
        public void ReturnAllArticles()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var article = new Article();
            var articles = new List<Article>() { article };

            var articlesSetMock = new Mock<DbSet<Article>>();
            articlesSetMock.SetupData(articles);

            dbContextMock.Setup(m => m.Articles).Returns(articlesSetMock.Object);

            var service = new ArticleServices(dbContextMock.Object);

            // Act
            var result = service.ListAllArticles().ToList();

            // Assert
            CollectionAssert.AreEqual(articles, result);
        }
    }
}
