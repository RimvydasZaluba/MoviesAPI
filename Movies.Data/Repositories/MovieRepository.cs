using System;
using System.Collections.Generic;
using System.Linq;
using Movies.Application.Data.Interfaces;
using Movies.Data.Contexts;
using Movies.Domain;
using Movies.Domain.Helper;

namespace Movies.Data.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _movieDb;

        public MovieRepository(MovieDbContext movieDb)
        {
            _movieDb = movieDb;
        }

        public IEnumerable<Movie> GetAll(FilterModel filter)
        {
            var movies = _movieDb.Movies
                //.Include(movie => movie.Genres)
                //    .ThenInclude(genre => genre.Genre)
                //.Include(movie => movie.Ratings)
                .Select(movie => movie);

            if (!string.IsNullOrEmpty(filter.TitleSearch))
            {
                movies = movies.Where(o => o.Title.Contains(filter.TitleSearch));
            }

            if (filter.ReleaseYearSearch.HasValue)
            {
                movies = movies.Where(o => o.ReleaseDate.Year == filter.ReleaseYearSearch.Value);
            }

            if(filter.GenreSearch != null && filter.GenreSearch.Any())
            {
                foreach (var genre in filter.GenreSearch)
                {
                    movies = movies.Where(o => o.Genres.Select(x => x.Genre.Name).Any(c => c.Equals(genre, StringComparison.InvariantCultureIgnoreCase) ));
                }
                
            }

            return movies.Select(o => new Movie
            {
                Id = o.Id,
                Title = o.Title,
                RunningTime = o.RunningTime,
                YearOfRelease = o.ReleaseDate.Year,
                AverageRating = CalculateRating(o.Ratings)
            }).ToList();
        }

        public IEnumerable<Movie> GetTop5()
        {
            return null;
        }

        private double CalculateRating(IEnumerable<Entities.Rating> ratings)
        {
            return ratings == null ? 0 : Math.Round(ratings.Average(x => x.Stars) * 2, MidpointRounding.AwayFromZero) / 2;
        }

    }
}
