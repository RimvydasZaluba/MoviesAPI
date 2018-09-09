using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Application.Data.Interfaces;
using Movies.Data.Contexts;
using Movies.Domain;
using System;
using System.Linq;

namespace Movies.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieDbContext _movieDb;
        private readonly ILogger<RatingRepository> _logger;

        public RatingRepository(MovieDbContext movieDb, ILogger<RatingRepository> logger)
        {
            _movieDb = movieDb;
            _logger = logger;
        }

        public bool UpdateAddRating(Rating rating)
        {

            var user = _movieDb.Users.Include(o => o.Ratings).FirstOrDefault(o => o.Id == rating.UserId);

            if (user == null)
            {
                _logger.LogInformation($"{rating.UserId}: User does not exist");
                return false;
            }

            var ratingEnt = user.Ratings.FirstOrDefault(o => o.MovieId == rating.MovieId);

            if (ratingEnt == null)
            {
                ratingEnt = new Entities.Rating { MovieId = rating.MovieId, UserId = rating.UserId, Stars = rating.Stars };
                _movieDb.Ratings.Add(ratingEnt);
                _movieDb.SaveChanges();
                return true;
            }

            if (ratingEnt.Stars == rating.Stars)
            {
                return true;
            }

            ratingEnt.Stars = rating.Stars;

            _movieDb.Ratings.Update(ratingEnt);
            _movieDb.SaveChanges();

            return true;

        }
    }
}
