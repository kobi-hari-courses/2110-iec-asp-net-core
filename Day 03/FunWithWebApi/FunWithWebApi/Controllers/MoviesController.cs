using FunWithWebApi.Entities.Entities;
using FunWithWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithWebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepositoryService _repository;

        public MoviesController(IMovieRepositoryService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{index}", Name = nameof(GetMovieAtIndex))]
        public ActionResult<Movie> GetMovieAtIndex(int index)
        {
            if (index < _repository.Count)
            {
                return Ok(_repository.GetMovie(index));
            }

            return NotFound($"Must be between 0 and {_repository.Count - 1}");
        }

        [HttpPost()]
        public ActionResult<Movie> AddMovie([FromBody] Movie movie)
        {
            _repository.AddMovie(movie);
            return CreatedAtRoute(nameof(GetMovieAtIndex), new { index = _repository.GetIndexOfMovie(movie.DisplayName) }, movie);
        }

        [HttpPut("{index}")]
        public ActionResult<Movie> ModifyMovie(int index, [FromBody] Movie movie)
        {
            if (index >= _repository.Count)
            {
                return NotFound($"Must be between 0 and {_repository.Count - 1}");
            }

            _repository.UpdateMovie(index, movie);
            return Ok(movie);
        }

        [HttpDelete("{index}")]
        public ActionResult<Movie> DeleteMovie(int index)
        {
            if (index >= _repository.Count)
            {
                return NotFound($"Must be between 0 and {_repository.Count - 1}");
            }

            var movie = _repository.GetMovie(index);
            _repository.DeleteMovie(index);
            return Ok(movie);

        }

    }
}
