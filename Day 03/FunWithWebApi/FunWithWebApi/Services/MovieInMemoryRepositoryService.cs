using FunWithWebApi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithWebApi.Services
{
    public class MovieInMemoryRepositoryService : IMovieRepositoryService
    {
        private List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                DisplayName = "Pulp Fiction",
                Description = "A very good movie",
                PublishedOn = new DateTime(1994, 10, 15)
            },
            new Movie
            {
                DisplayName = "Kill Bill 1",
                Description = "A very good movie",
                PublishedOn = new DateTime(2003, 12, 10)
            },
            new Movie
            {
                DisplayName = "Kill Bill 2",
                Description = "A very good movie",
                PublishedOn = new DateTime(2004, 8, 30)
            },
        };

        public IEnumerable<Movie> GetAll()
        {
            return _movies.ToList();
        }

        public Movie GetMovie(int index)
        {
            return _movies[index];
        }

        public int Count => _movies.Count;

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public int GetIndexOfMovie(string movieName)
        {
            return _movies.FindIndex(m => m.DisplayName == movieName);
        }

        public void UpdateMovie(int index, Movie movie)
        {
            _movies[index] = movie;
        }

        public void DeleteMovie(int index)
        {
            _movies.RemoveAt(index);
        }
    }
}
