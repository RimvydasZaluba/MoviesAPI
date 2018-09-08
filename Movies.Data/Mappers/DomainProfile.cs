using AutoMapper;

namespace Movies.Data.Mappers
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<Entities.Genre, Domain.Genre>();
            CreateMap<Entities.Movie, Domain.Movie>();
            CreateMap<Entities.User, Domain.User>();
            CreateMap<Entities.MovieGenre, Domain.MovieGenre>();
            CreateMap<Entities.Rating, Domain.Rating>();            
        }
    }
}
