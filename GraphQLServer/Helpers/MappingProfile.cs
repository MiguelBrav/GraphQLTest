using AutoMapper;
using GraphQLServer.GraphQl.Types;
using GraphQLServer.Models;

namespace GraphQLServer.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publicacion, PublicacionInputType>()
             .ReverseMap().
              ForMember(x => x.Autor, pubInput => pubInput.Ignore())
              .ForMember(x => x.Categoria, pubInput => pubInput.Ignore());

            CreateMap<Publicacion, PublicacionPayload>()
             .ReverseMap().
              ForMember(x => x.Autor, pubInput => pubInput.Ignore())
              .ForMember(x => x.Categoria, pubInput => pubInput.Ignore());

            CreateMap<Autor, AutorInputType>()
                .ReverseMap();

            CreateMap<Autor, AutorPayload>()
                .ReverseMap();

            CreateMap<Categoria, CategoriaInputType>()
                .ReverseMap();

            CreateMap<Categoria, CategoriaPayload>()
                .ReverseMap();
        }
    }
}
