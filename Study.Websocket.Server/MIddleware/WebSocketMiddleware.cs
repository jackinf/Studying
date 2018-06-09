using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Study.Websocket.Server.MIddleware
{
    public class WebSocketMiddleware
    {
        public static async Task ProcessRequest(HttpContext context, Func<Task> next)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await next();
                return;
            }

            var hub = context.RequestServices.GetService<Hub>();
            var ws = await context.WebSockets.AcceptWebSocketAsync();

            switch (context.Request.Path.Value.ToLowerInvariant())
            {
                case "/hello":
                    await hub.SayHello(ws);
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
            }
        }

    }
}