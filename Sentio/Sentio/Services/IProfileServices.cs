using Sentio.Data.DataModels;
using Sentio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Services
{
    public interface IProfileServices
    {
        void JoinEvent(int eventId, string userName);

        IEnumerable<EventModel> EventsForUser(string userName);
    }
}
