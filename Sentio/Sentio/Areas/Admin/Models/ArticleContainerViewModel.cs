using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Areas.Admin.Models
{
    public class ArticleContainerViewModel
    {
        public ArticleViewModel CreateArticle { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}