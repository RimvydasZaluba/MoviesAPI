using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Data.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> Movies { get; set; }
    }
}
