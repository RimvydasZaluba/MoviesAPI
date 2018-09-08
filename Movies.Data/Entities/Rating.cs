using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Data.Entities
{
    public class Rating
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Key, Column(Order = 1)]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        public int Stars { get; set; }
    }
}
