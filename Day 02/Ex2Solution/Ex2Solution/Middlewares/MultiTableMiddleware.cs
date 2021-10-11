using Ex2Solution.Service;
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
        private MultiplicationService _calcService;

        public MultiTableMiddleware(RequestDelegate next, 
            MultiplicationService calcService)
        {
            _calcService = calcService;
        }

        public async Task Invoke(HttpContext context, HtmlTableService htmlService, ParameterService paramService)
        {
            // TODO: Read this from the previous middleware
            var size = paramService.Size;

            var table = _calcService.CreateTable(size);
            await htmlService.WriteToHtml(context, table);
        }

    }

    public static class MultiTableMiddlewareExtensions
    {
        public static IApplicationBuilder UseMultiTable(this IApplicationBuilder app)
        {
            app.Map("/multable", builder =>
            {
                builder.UseMiddleware<SizeReaderMiddleware>();
                builder.UseMiddleware<MultiTableMiddleware>();
            });

            return app;
        }
    }
}
