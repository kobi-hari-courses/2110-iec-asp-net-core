using FunWithWebApi.Entities.Entities;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunWithWebApi.Services
{
    public interface IMovieRepositoryService: IHostedService
    {
        Task<int> GetCount();

        Task AddMovie(Movie movie);
        
        Task<IEnumerable<Movie>> GetAll();

        Task<Movie> GetMovie(int index);

        Task<int> GetIndexOfMovie(string movieName);

        Task UpdateMovie(int index, Movie movie);

        Task DeleteMovie(int index);
    }

}