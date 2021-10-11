using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex2Solution.Service
{
    public class HtmlTableService
    {
        private IServiceProvider _provider;

        public HtmlTableService()
        {
        }

        public async Task WriteToHtml(HttpContext context, int[,] matrix)
        {
            await context.Response.WriteAsync("<table>");
            await context.Response.WriteAsync("<thead><tr>");

            await context.Response.WriteAsync($"<th></th>");
            for (int i = 1; i <= matrix.GetLength(1); i++)
            {
                await context.Response.WriteAsync($"<th>{i}</th>");
            }

            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                await context.Response.WriteAsync($"<tr>");
                await context.Response.WriteAsync($"<th>{i}</th>");

                for (int j = 1; j <= matrix.GetLength(1); j++)
                {
                    await context.Response.WriteAsync($"<td>{matrix[i-1, j-1]}</td>");
                }

                await context.Response.WriteAsync($"</tr>");
            }

            await context.Response.WriteAsync("</tr></thead>");

            await context.Response.WriteAsync("</table>");

        }
    }
}
