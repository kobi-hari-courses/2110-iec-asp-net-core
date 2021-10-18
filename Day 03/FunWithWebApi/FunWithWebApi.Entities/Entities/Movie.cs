using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithWebApi.Entities.Entities
{
    public class Movie
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}

