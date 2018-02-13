using System.Collections.Generic;

namespace Sentio.Data.DataModels
{
    public class Article
    {
        public Article()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
