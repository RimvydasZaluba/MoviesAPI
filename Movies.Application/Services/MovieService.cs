using Movies.Application.Data.Interfaces;
using Movies.Application.Services.Interfaces;
using Movies.Domain;
using Movies.Domain.Helper;
using System.Collections.Generic;

namespace Movies.Application.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAll(FilterModel filter)
        {
            return _movieRepository.GetAll(filter);
        }

        public IEnumerable<Movie> GetTop5()
        {
            return _movieRepository.GetTop5();
        }

        public IEnumerable<Movie> GetTop5ByUser(int userId)
        {
            return _movieRepository.GetTop5ByUser(userId);
        }
    }
}
