using System;
using System.IO;
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
                await ws.SendAsync(buffer.Array, WebSocketMessageType.Text, true, token);
                Console.WriteLine("Sent");
            }

            tsc.Cancel();
            await t;
            await ws.CloseAsync(WebSocketCloseStatus.Empty, "", token);
        }

        private static async Task Receive(ClientWebSocket webSocket, CancellationToken token)
        {
            while (webSocket.State == WebSocketState.Open)
            {
                using (var ms = new MemoryStream())
                {
                    var buffer = new ArraySegment<byte>(new byte[8192]);
                    WebSocketReceiveResult result;
                    do
                    {
                        result = await webSocket.ReceiveAsync(buffer, token);
                        ms.Write(buffer.Array, buffer.Offset, buffer.Count);
                    } while (!result.EndOfMessage);

                    ms.Seek(0, SeekOrigin.Begin);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
                    }
                    else
                    {
                        using (var reader = new StreamReader(ms, Encoding.UTF8))
                        {
                            var json = await reader.ReadToEndAsync();
                            var message = JsonConvert.DeserializeObject<Message<string>>(json);
                            Console.WriteLine(message.Data);
                        }
                    }
                }
            }
        }
    }
}