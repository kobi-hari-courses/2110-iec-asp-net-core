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
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{index}", Name = nameof(GetMovieAtIndex))]
        public async Task<ActionResult<Movie>> GetMovieAtIndex(int index)
        {
            var count = await _repository.GetCount();

            if (index < count)
            {
                return Ok(await _repository.GetMovie(index));
            }

            return NotFound($"Must be between 0 and {count - 1}");
        }

        [HttpPost()]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            await _repository.AddMovie(movie);
            var index = await _repository.GetIndexOfMovie(movie.Caption);

            return CreatedAtRoute(nameof(GetMovieAtIndex), new { index = index }, movie);
        }

        [HttpPut("{index}")]
        public async Task<ActionResult<Movie>> ModifyMovie(int index, [FromBody] Movie movie)
        {
            var count = await _repository.GetCount();

            if (index >= count)
            {
                return NotFound($"Must be between 0 and {count - 1}");
            }

            await _repository.UpdateMovie(index, movie);
            return Ok(movie);
        }
        
        [HttpDelete("{index}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int index)
        {
            var count = await _repository.GetCount();

            if (index >= count)
            {
                return NotFound($"Must be between 0 and {count - 1}");
            }

            var movie = await _repository.GetMovie(index);
            await _repository.DeleteMovie(index);
            return Ok(movie);

        }

    }
}
