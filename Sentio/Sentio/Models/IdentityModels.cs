using Microsoft.AspNet.Identity.EntityFramework;
using Sentio.Data.DataModels;
using System.Data.Entity;

namespace Sentio.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Like> Likes { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Event> Events { get; set; }
 
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}