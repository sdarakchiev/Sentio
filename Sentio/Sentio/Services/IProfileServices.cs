using Sentio.Data.Models;
using System.Collections.Generic;

namespace Sentio.Services
{
    public interface IProfileServices
    {
        void JoinEvent(int eventId, string userName);

        IEnumerable<EventModel> EventsForUser(string userName);
    }
}
