using Sentio.Data.DataModels;
using Sentio.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sentio.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The artile must be between 200 and 1000 symbols", MinimumLength = 200)]
        public string Content { get; set; }

        public ArticleCommentViewModel CommentViewModel { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}