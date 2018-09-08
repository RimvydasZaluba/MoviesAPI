using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Application.Services.Interfaces;
using Movies.Domain.Helper;

namespace MoviesAPI.Controllers
{
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve all the movie records
        /// </summary>
        /// <param name="titleSearch">string</param>
        /// <param name="releaseYearSearch">int</param>
        /// <param name="genreSearch">comma delimited list</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll(string titleSearch = null, int? releaseYearSearch = null, string genreSearch = null)
        {
            try
            {
                if(string.IsNullOrEmpty(titleSearch) && !releaseYearSearch.HasValue && string.IsNullOrEmpty(genreSearch))
                {
                    _logger.LogInformation("No filter was provided");
                    return BadRequest();
                }

                var filter = new FilterModel
                {
                    TitleSearch = titleSearch,
                    ReleaseYearSearch = releaseYearSearch,
                    GenreSearch = !string.IsNullOrEmpty(genreSearch) ? genreSearch.Split(',') : null
                };


                var movies = _movieService.GetAll(filter);


                if (movies == null || !movies.Any())
                {
                    _logger.LogInformation("No movies were found with the requested filters");
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Get top 5 rated movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("top5")]
        public IActionResult GetTop5()
        {
            try
            {
                var movies = _movieService.GetTop5();

                if (movies == null || !movies.Any())
                {
                    _logger.LogInformation("No movies were found with the requested filters");
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Get top 5 specific user rated movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("top5/{userId}")]
        public IActionResult GetTop5ByUser(int userId)
        {
            try
            {
                var movies = _movieService.GetTop5ByUser(userId);

                if (movies == null || !movies.Any())
                {
                    _logger.LogInformation("No movies were found with the requested filters");
                    return NotFound();
                }

                return Ok(movies);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }

    }
}