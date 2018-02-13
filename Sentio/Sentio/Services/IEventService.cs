using Sentio.Data.DataModels;
using System.Collections.Generic;

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
