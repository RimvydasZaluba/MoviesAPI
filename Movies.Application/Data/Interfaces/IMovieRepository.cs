using Movies.Domain;
using System.Collections.Generic;

namespace Movies.Application.Data.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
