using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Study.Websocket.Common;

namespace Study.Websocket.Client
{
    public class WebsocketNetApp
    {
        public static async Task RunAsync(string url, CancellationToken token)
        {
            var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri(url), token);

            var tsc = new CancellationTokenSource();
            var token1 = tsc.Token;
            var t = Task.Run(() => Receive(ws, token1));

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                if (token.IsCancellationRequested)
                    break;

                var message = new Message<string> { Data = "Hello world" };
                var json = JsonConvert.SerializeObject(message);
                var bytes = Encoding.UTF8.GetBytes(json);
                var buffer = new ArraySegment<byte>(bytes);
                await ws.SendAsync(buffer.Array, WebSocketMessageType.Binary, true, token);
                Console.WriteLine("Sent");
            }

            tsc.Cancel();
            await t;
            await ws.CloseAsync(WebSocketCloseStatus.Empty, "", token);
        }

        private static async Task Receive(ClientWebSocket webSocket, CancellationToken token)
        {
            byte[] buffer = new byte[8192];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
                }
                else
                {
                    var json = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(json);
                }
            }
        }
    }
}