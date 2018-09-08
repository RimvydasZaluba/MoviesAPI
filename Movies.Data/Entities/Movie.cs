using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
