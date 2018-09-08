using Movies.Application.Data.Interfaces;
using Movies.Application.Services.Interfaces;
using Movies.Domain;
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

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }
    }
}
