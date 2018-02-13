using System.ComponentModel.DataAnnotations;

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
