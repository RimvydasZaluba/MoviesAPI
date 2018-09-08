using Movies.Domain;
using System.Collections.Generic;

namespace Movies.Application.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
    }
}
