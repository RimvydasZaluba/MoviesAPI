using Movies.Domain;
using Movies.Domain.Helper;
using System.Collections.Generic;

namespace Movies.Application.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll(FilterModel filter);
        IEnumerable<Movie> GetTop5();
        IEnumerable<Movie> GetTop5ByUser(int userId);
    }
}
