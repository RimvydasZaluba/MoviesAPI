namespace MoviesAPI.Model
{
    public class RatingInput
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Stars { get; set; }
    }
}
