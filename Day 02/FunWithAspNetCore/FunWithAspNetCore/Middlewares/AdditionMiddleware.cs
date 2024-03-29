﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithAspNetCore.Middlewares
{
    public class AdditionMiddleware
    {
        private readonly RequestDelegate _next;

        public AdditionMiddleware(RequestDelegate next)
        {
            _next = next;
            Console.WriteLine("Addition middleware created");
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToString();
            var result = url
                .Split("/")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => int.Parse(s))
                .Sum();
            await context.Response.WriteAsync("The answer is : " + result);
        }
    }

    public static class AdditionMiddlewareExtension 
    {
        public static IApplicationBuilder UseAddition(this IApplicationBuilder app, string path = "add")
        {
            app.Map($"/{path}", 
            builder =>
            {
                builder.UseMiddleware<AdditionMiddleware>();
            });

            return app;
        }
    }
}
