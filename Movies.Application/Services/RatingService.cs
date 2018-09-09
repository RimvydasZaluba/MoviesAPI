using Movies.Application.Data.Interfaces;
using Movies.Application.Services.Interfaces;
using Movies.Domain;

namespace Movies.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public bool UpdateAddRating(Rating rating)
        {
            return _ratingRepository.UpdateAddRating(rating);
        }
    }
}
