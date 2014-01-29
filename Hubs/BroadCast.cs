using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ConferenceDashborad.Hubs
{
    public class BroadCast : Hub
    {
        public void Hello()
        {
            var cont = GlobalHost.ConnectionManager.GetHubContext<BroadCast>();
            cont.Clients.All.addNewMessageToPage();
           // Clients.All.addNewMessageToPage();
        }
    }
}