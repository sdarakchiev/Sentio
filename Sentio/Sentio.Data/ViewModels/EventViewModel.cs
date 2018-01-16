using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Data.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
    }
}
