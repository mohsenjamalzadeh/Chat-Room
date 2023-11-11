using Microsoft.AspNetCore.SignalR;

namespace ServiceHost.Hubs
{
	public class ChatHub : Hub
	{

		public override Task OnConnectedAsync()
		{
			Clients.All.SendAsync("SendClientMessage");
			return base.OnConnectedAsync();
		}

		//public async Task SendMessge()
		//      {
		//          await Clients.All.SendAsync("SendClientMessage");
		//      }
	}
}
