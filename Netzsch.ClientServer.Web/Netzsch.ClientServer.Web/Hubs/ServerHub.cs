using Microsoft.AspNetCore.SignalR;

namespace Netzsch.ClientServer.Web.Hubs
{
    public class ServerHub: Hub
    {
        private const string CLIENT_RECEIVE_MESSAGE = "ReceiveMessage";

        public async Task SendMessage(string inputValue, string outputValue)
        {
            await Clients.All.SendAsync(CLIENT_RECEIVE_MESSAGE, inputValue, outputValue);
        }
    }
}
