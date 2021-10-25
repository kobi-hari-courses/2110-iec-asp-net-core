using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoviesApp.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesApp.Services
{
    public class InitService : IHostedService
    {
        private IWebHostEnvironment _environment;
        private IServiceProvider _serviceProvider;

        public InitService(IWebHostEnvironment environment, IServiceProvider serviceProvider)
        {
            _environment = environment;
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (_environment.IsDevelopment())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
                    await context.Database.MigrateAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
