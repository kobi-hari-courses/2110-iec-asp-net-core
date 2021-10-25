using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviesApp.Db;
using MoviesApp.Model;
using MoviesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = new ConnectionStringSettings();

             Configuration
                .GetSection("ConnectionStrings")
                .Bind(connectionStrings);

            services.AddControllers();
            services.AddHostedService<InitService>();

            
            if (Environment.IsProduction())
            {
                services.AddDbContext<MoviesDbContext>(builder =>
                {
                    builder.UseSqlite(connectionStrings.Default);
                });
            } else
            {
                services.AddDbContext<MoviesDbContext>(builder =>
                {
                    builder.UseSqlServer(connectionStrings.Default);
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
