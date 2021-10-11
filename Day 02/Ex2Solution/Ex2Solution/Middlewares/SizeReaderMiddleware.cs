using Ex2Solution.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex2Solution.Middlewares
{
    public class SizeReaderMiddleware
    {
        private RequestDelegate _next;

        public SizeReaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ParameterService paramService)
        {
            var sizeString = context.Request.Query["size"].ToString();
            if (int.TryParse(sizeString, out int size))
            {
                paramService.Size = size;
                await _next(context);
            }
        }
    }
}
