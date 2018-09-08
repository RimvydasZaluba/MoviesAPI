
namespace Movies.Domain
{
    public class Rating
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int Stars { get; set; }
    }
}
