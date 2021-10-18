using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithWebApi.Entities.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string Poster { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}

