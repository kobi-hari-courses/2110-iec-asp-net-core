using FunWithEntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEntityFramework
{
    public class UniversityDbContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = University; Trusted_Connection = True; ";

            optionsBuilder
                .UseSqlServer(connectionString)
                .LogTo(msg =>
                {
                    var previosColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = previosColor;
                });

        }
    }
}
