using Sentio.Data.DataModels;
using Sentio.Data.Models;
using System.Collections.Generic;

namespace Sentio.Areas.Admin.Services
{
    public interface IArticleServices
    {
        void AddArticle(string author, string title, string content);

        Article FindArticle(int articleId);

        void DeleteArticle(Article article);

        IEnumerable<Article> ListAllArticles();

        IEnumerable<ArticleModel> GetTopArticles(int count);

        void AddComment(int articleId, string content);

        IEnumerable<Comment> AllComments(int articleId);

        void AddLike(int articleId);

        ICollection<Like> AllArticleLikes(int articleId);
    }
}
