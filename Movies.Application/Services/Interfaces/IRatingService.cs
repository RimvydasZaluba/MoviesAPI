using Movies.Domain;

namespace Movies.Application.Services.Interfaces
{
    public interface IRatingService
    {
        bool UpdateAddRating(Rating rating);
    }
}
