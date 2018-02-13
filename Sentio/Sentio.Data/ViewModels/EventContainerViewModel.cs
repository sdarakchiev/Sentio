using System.Collections.Generic;

namespace Sentio.Data.ViewModels
{
    public class EventContainerViewModel
    {
        public EventViewModel CreateEvent { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
