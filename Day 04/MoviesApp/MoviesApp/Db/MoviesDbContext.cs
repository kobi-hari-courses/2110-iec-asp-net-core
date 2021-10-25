using Microsoft.EntityFrameworkCore;
using MoviesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Db
{
    public class MoviesDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            :base(options)
        {

        }

    }
}
