using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Application.Services.Interfaces;
using Movies.Domain;
using MoviesAPI.Model;

namespace MoviesAPI.Controllers
{
    [Route("api/ratings")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
        {
            _ratingService = ratingService;
            _logger = logger;
        }

        /// <summary>
        /// Update or create a new rating for a movie
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(RatingInput rating)
        {
            try
            {
                if(rating.Stars < 1 && rating.Stars > 5)
                {
                    return BadRequest();
                }



                var res = _ratingService.UpdateAddRating(new Rating
                {
                    MovieId = rating.MovieId,
                    UserId = rating.UserId,
                    Stars = rating.Stars
                });

                if (!res)
                {
                    return NotFound("User not found");
                }

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }

        }
    }
}