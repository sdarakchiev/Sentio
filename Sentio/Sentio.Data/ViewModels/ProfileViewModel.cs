using System.Collections.Generic;

namespace Sentio.Data.ViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public ICollection<EventViewModel> Events { get; set; }
    }
}
