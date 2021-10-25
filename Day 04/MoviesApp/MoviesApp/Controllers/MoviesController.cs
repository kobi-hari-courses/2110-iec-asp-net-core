using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Db;
using MoviesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MoviesController(MoviesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            return Ok(movies);
        }

    }
}
