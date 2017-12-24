using Sentio.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Areas.Admin.Models
{
    public class DeleteArticleViewModel
    {
        public bool Selected { get; set; }

        public Article Article { get; set; }
    }
}