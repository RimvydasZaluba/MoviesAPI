using Movies.Domain;

namespace Movies.Application.Data.Interfaces
{
    public interface IRatingRepository
    {
        bool UpdateAddRating(Rating rating);
    }
}
