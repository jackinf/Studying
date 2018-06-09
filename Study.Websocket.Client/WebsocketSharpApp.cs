using System;
using System.Text;
using Newtonsoft.Json;
using Study.Websocket.Common;
using WebSocketSharp;

namespace Study.Websocket.Client
{
    public class WebsocketSharpApp
    {
        public static void Run(string url)
        {
            using (var ws = new WebSocket(url))
            {
                ws.OnMessage += (sender, e) => Console.WriteLine("Received: " + e.Data);
                ws.Connect();

                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    var message = new Message<string> { Data = "Hello world" };
                    var json = JsonConvert.SerializeObject(message);
                    ws.Send(Encoding.UTF8.GetBytes(json));
                    Console.WriteLine("Sent");
                }
                ws.Close();
            }
        }
    }
}