using FunWithWebApi.Entities.Entities;
using System.Collections.Generic;

namespace FunWithWebApi.Services
{
    public interface IMovieRepositoryService
    {
        int Count { get; }

        void AddMovie(Movie movie);
        IEnumerable<Movie> GetAll();
        Movie GetMovie(int index);

        int GetIndexOfMovie(string movieName);

        void UpdateMovie(int index, Movie movie);

        void DeleteMovie(int index);
    }

}