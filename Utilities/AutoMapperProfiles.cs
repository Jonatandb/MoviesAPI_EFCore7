using AutoMapper;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

namespace MoviesAPI_EFCore7.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<ComentarioCreacionDTO, Comentario>();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto =>
                dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
