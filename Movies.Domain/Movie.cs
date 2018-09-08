using System;
using System.Collections.Generic;

namespace Movies.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
