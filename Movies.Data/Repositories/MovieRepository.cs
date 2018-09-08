using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Data.Interfaces;
using Movies.Data.Contexts;
using Movies.Domain;

namespace Movies.Data.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly MovieDbContext _movieDb;
        private readonly IMapper _mapper;

        public MovieRepository(MovieDbContext movieDb, IMapper mapper)
        {
            _movieDb = movieDb;
            _mapper = mapper;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieDb.Movies
                .Include(movie => movie.Genres)
                .Include(movie => movie.Ratings)
                .ToList().Select(o => _mapper.Map<Movie>(o));
        }
    }
}
