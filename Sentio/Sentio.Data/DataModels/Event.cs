using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Data.DataModels
{
    public class Event
    {
        private ICollection<ApplicationUser> users;

        public Event()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}
