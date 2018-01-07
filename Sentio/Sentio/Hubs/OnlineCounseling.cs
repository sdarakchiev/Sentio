using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Hubs
{
    public class OnlineCounseling : Hub
    {
        public void SendMessage (string message)
        {
            string sentMessage = $"{this.Context.User.Identity.Name}: {message}";
            Clients.All.newMessage(sentMessage);
        }
    }
}