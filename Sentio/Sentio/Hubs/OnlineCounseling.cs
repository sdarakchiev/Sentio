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
            string userName = this.Context.User.Identity.Name;
            string name = userName.Substring(0, userName.IndexOf('@'));
            string sentMessage = $"{name}: {message}";
            Clients.All.newMessage(sentMessage);
        }
    }
}