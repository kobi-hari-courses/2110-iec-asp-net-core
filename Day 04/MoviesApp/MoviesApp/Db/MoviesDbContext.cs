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

        public DbSet<Actor> Actors { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>(ent =>
            {
                ent.HasKey(nameof(Movie.Id));
                ent.Property(nameof(Movie.Id)).ValueGeneratedNever();
                ent.HasIndex(nameof(Movie.DisplayName));
            });

            builder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5da"), 
                    FirstName = "Bruce", 
                    LastName = "Willies"
                },
                new Actor
                {
                    Id = new Guid("31412b61-1020-41fa-9c3d-fc2cd972d5db"),
                    FirstName = "John",
                    LastName = "Travolta"
                }
                );
            
        }
    }
}
