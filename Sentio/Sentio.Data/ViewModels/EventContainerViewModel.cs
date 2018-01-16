using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Data.ViewModels
{
    public class EventContainerViewModel
    {
        public EventViewModel CreateEvent { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
