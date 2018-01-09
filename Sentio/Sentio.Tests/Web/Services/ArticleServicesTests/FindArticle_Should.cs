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
    public class FindArticle_Should
    {
        [TestMethod]
        public void ReturnCorrectArticle_WhenIdIsValid()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var articleSetMock = new Mock<DbSet<Article>>();

            var article = new Article() { Id = 1 };
            var articles = new List<Article>()
            {
                article
            };

            articleSetMock.SetupData(articles);
            dbContextMock.Setup(m => m.Articles).Returns(articleSetMock.Object);

            ArticleServices service = new ArticleServices(dbContextMock.Object);

            //Act
            var result = service.FindArticle(1);

            //Assert
            Assert.AreSame(article, result);
        }
    }
}
