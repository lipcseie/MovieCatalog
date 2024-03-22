using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte GenreId { get; set; }

        public Genre? Genres { get; set; }

        public Classification Classification { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        public ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();

    }
}
