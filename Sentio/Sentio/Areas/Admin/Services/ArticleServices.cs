﻿using Bytes2you.Validation;
using Sentio.Areas.Admin.Models;
using Sentio.Data.DataModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Areas.Admin.Services
{
    public class ArticleServices : IArticleServices
    {
        private readonly ApplicationDbContext dbContext;

        public ArticleServices(ApplicationDbContext dbContext)
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

        public Article FindArticle (int articleId)
        {
            var article = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleId);

            return article;
        }

        public void DeleteArticle (Article article)
        {
            Guard.WhenArgument(article, "article").IsNull().Throw();

            this.dbContext.Articles.Remove(article);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<Article> ListAllArticles ()
        {
            return this.dbContext.Articles.ToList();
        }
    }
}