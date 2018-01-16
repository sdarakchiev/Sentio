using Sentio.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Services
{
    public interface IEventService
    {
        void CreateEvent(string name, string description);

        Event GetEvent(int id);

        IEnumerable<Event> AllEvents();

        void DeleteEvent(Event theEvent);
    }
}
