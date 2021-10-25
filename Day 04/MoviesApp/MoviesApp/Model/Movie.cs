using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string Poster { get; set; }

        public  string Description { get; set; }
    }
}
