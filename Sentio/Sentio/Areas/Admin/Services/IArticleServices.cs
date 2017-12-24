using Sentio.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Areas.Admin.Services
{
    public interface IArticleServices
    {
        void AddArticle(string author, string title, string content);

        Article FindArticle(int articleId);

        void DeleteArticle(Article article);

        IEnumerable<Article> ListAllArticles();
    }
}
