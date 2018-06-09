using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Study.Websocket.Common;

namespace Study.Websocket.Server.Extension
{
    public static class WebSocketExtension
    {
        public static async Task Send<T>(this WebSocket ws, T data)
        {
            var message = new Message<T> {Data = data};
            var json = JsonConvert.SerializeObject(message);
            var bytes = Encoding.UTF8.GetBytes(json);
            var buffer = new ArraySegment<byte>(bytes);
            await ws.SendAsync(buffer.Array, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public static async Task<Message<T>> Receive<T>(this WebSocket ws)
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                    ms.Write(buffer.Array, buffer.Offset, buffer.Count);
                } while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);

                if (result.CloseStatus.HasValue)
                    return null;

                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    var json = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<Message<T>>(json);
                }
            }
        }
    }
}