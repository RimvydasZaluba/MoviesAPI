using System.Collections.Generic;

namespace Movies.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> Movies { get; set; }
    }
}
