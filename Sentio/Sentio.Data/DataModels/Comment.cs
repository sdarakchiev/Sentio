namespace Sentio.Data.DataModels
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string Content { get; set; }
    }
}
