using FunWithWebApi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithWebApi.Services
{
    public class MovieJsonFileRepositoryService : IMovieRepositoryService
    {
        private const string fileName = "Data/movies.json";
        private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private async Task<List<Movie>> _readAllMovies()
        {
            var json = await File.ReadAllTextAsync(fileName);
            var res = JsonSerializer.Deserialize<List<Movie>>(json, jsonOptions);
            return res;
        }

        private async Task _writeAllMovies(List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies, jsonOptions);
            await File.WriteAllTextAsync(fileName, json);          
        }

        public async Task AddMovie(Movie movie)
        {
            var movies = await _readAllMovies();
            movies.Add(movie);
            await _writeAllMovies(movies);
        }

        public async Task DeleteMovie(int index)
        {
            var movies = await _readAllMovies();
            movies.RemoveAt(index);
            await _writeAllMovies(movies);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = await _readAllMovies();
            return movies;
        }

        public async Task<int> GetCount()
        {
            var movies = await _readAllMovies();
            return movies.Count;
        }

        public async Task<int> GetIndexOfMovie(string movieName)
        {
            var movies = await _readAllMovies();
            return movies.FindIndex(m => m.Caption == movieName);
        }

        public async Task<Movie> GetMovie(int index)
        {
            var movies = await _readAllMovies();
            return movies[index];
        }

        public async Task UpdateMovie(int index, Movie movie)
        {
            var movies = await _readAllMovies();
            movies[index] = movie;
            await _writeAllMovies(movies);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
