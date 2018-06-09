using System;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Websocket.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any button to send message. Press escape to quit");

            const string url = "ws://localhost:50221/hello";
            //WebsocketSharpApp.Run(url);
            await WebsocketNetApp.RunAsync(url, CancellationToken.None);
        }
    }
}
