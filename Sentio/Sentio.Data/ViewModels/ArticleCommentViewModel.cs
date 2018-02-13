using System.ComponentModel.DataAnnotations;

namespace Sentio.Data.ViewModels
{
    public class ArticleCommentViewModel
    {
        public string UserId { get; set; }

        public int ArticleId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
