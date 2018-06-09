using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Study.Websocket.Server.MIddleware
{
    public class HttpMiddleware
    {
        public static async Task ProcessRequest(HttpContext context, Func<Task> next)
        {
            await context.Response.WriteAsync("Hi");
        }
    }
}