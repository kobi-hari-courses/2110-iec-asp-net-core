using FunWithWebApi.Entities.Entities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithWebApi.Services
{
    public class MovieInMemoryRepositoryService : IMovieRepositoryService
    {
        private List<Movie> _movies; 

        public Task<IEnumerable<Movie>> GetAll()
        {
            return Task.FromResult<IEnumerable<Movie>>(_movies.ToList());
        }

        public Task<Movie> GetMovie(int index)
        {
            return Task.FromResult(_movies[index]);
        }

        public Task<int> GetCount()
        {
            return Task.FromResult(_movies.Count);
        }

        public Task AddMovie(Movie movie)
        {
            _movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task<int> GetIndexOfMovie(string movieName)
        {
            return Task.FromResult(_movies.FindIndex(m => m.Caption == movieName));
        }

        public Task UpdateMovie(int index, Movie movie)
        {
            _movies[index] = movie;
            return Task.CompletedTask;
        }

        public Task DeleteMovie (int index)
        {
            _movies.RemoveAt(index);
            return Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(3000);

            _movies = new List<Movie>
            {
                new Movie
                {
                    Caption = "Pulp Fiction",
                    Description = "A very good movie",
                    PublishedOn = new DateTime(1994, 10, 15)
                },
                new Movie
                {
                    Caption = "Kill Bill 1",
                    Description = "A very good movie",
                    PublishedOn = new DateTime(2003, 12, 10)
                },
                new Movie
                {
                    Caption = "Kill Bill 2",
                    Description = "A very good movie",
                    PublishedOn = new DateTime(2004, 8, 30)
                },
            };
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
