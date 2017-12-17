using Sentio.Data.DataModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Areas.Admin.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ApplicationDbContext dbContext;

        public AdminServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddArticle(string author, string title, string content)
        {
            Article article = new Article()
            {
                Author = author,
                Title = title,
                Content = content
            };

            this.dbContext.Articles.Add(article);
            this.dbContext.SaveChanges();

        }
    }
}
