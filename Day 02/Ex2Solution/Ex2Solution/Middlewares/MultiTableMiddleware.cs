using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex2Solution.Middlewares
{
    public class MultiTableMiddleware
    {
        public MultiTableMiddleware(RequestDelegate next)
        {

        }

        public async Task Invoke(HttpContext context)
        {
            var sizeString = context.Request.Query["size"].ToString();
            if (int.TryParse(sizeString, out int size))
            {
                await context.Response.WriteAsync("<table>");
                await context.Response.WriteAsync("<thead><tr>");

                await context.Response.WriteAsync($"<th></th>");
                for (int i = 1; i <= size; i++)
                {
                    await context.Response.WriteAsync($"<th>{i}</th>");
                }

                for (int i = 1; i <= size; i++)
                {
                    await context.Response.WriteAsync($"<tr>");
                    await context.Response.WriteAsync($"<th>{i}</th>");

                    for (int j = 1; j <= size; j++)
                    {
                        await context.Response.WriteAsync($"<td>{i*j}</td>");
                    }

                    await context.Response.WriteAsync($"</tr>");
                }

                await context.Response.WriteAsync("</tr></thead>");

                await context.Response.WriteAsync("</table>");
            }

        }

    }

    public static class MultiTableMiddlewareExtensions
    {
        public static IApplicationBuilder UseMultiTable(this IApplicationBuilder app)
        {
            app.Map("/multable", builder =>
            {
                builder.UseMiddleware<MultiTableMiddleware>();
            });

            return app;
        }
    }
}
