using FunWithAspNetCore.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithAspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAddition("sum");


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<h1>Hi, I am the first middleware, registered with USE</h1>");
                await next();
                await context.Response.WriteAsync("<h1>Hi again, its the first middleware, on the way back</h1>");
            });

            app.Map("/help", builder =>
            {
                builder.Run(async ctxt =>
                {
                    await ctxt.Response.WriteAsync("<hr><h3>This is your help!!!</h3>");
                });
            });

            app.MapWhen(ctxt => ctxt.Request.Path.Value.Length > 10, builder =>
            {
                builder.Run(async ctxt =>
                {
                    await ctxt.Response.WriteAsync("<h4>Wow Wow Wow, what a big request!!!</h4>");
                });
            });


            app.Run(async context =>
            {
                await context.Response.WriteAsync("<h2>Hello World</h2>");
            });



            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
