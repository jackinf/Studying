using System.Net.WebSockets;
using System.Threading.Tasks;
using Study.Websocket.Common;
using Study.Websocket.Server.Extension;

namespace Study.Websocket.Server
{
    public class Hub
    {
        public async Task SayHello(WebSocket ws)
        {
            while (true)
            {
                var message = await ws.Receive<string>();
                if (message == null)
                    break;
                await ws.Send($"Got {message.Data}. Right back at ya.");
            }
        }
    }
}