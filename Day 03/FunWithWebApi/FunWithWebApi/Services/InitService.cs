using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithWebApi.Services
{
    public class InitService : IHostedService
    {
        private readonly IMovieRepositoryService _movieRepository;

        public InitService(IMovieRepositoryService movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _movieRepository.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _movieRepository.StopAsync(cancellationToken);
        }
    }
}
