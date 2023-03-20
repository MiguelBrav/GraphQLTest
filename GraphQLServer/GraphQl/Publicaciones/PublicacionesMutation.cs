using AutoMapper;
using GraphQLServer.Data;
using GraphQLServer.GraphQl.Types;
using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PublicacionesMutation
    {
      
        public async Task<PublicacionPayload> CreatePublication(Context context, PublicacionInputType inputPublication, [Service] IMapper mapper)
        {

            var publicacion = mapper.Map<Publicacion>(inputPublication);

            await context.Publicaciones.AddAsync(publicacion);

            await context.SaveChangesAsync();

            return mapper.Map<PublicacionPayload>(publicacion);

        }

        public async Task<PublicacionPayload> UpdatePublication(Context context, PublicacionInputType inputPublication, int publicationId, [Service] IMapper mapper)
        {

            var publicacion = mapper.Map<Publicacion>(inputPublication);

            publicacion.Id = publicationId;

            context.Publicaciones.Update(publicacion);

            await context.SaveChangesAsync();

            return mapper.Map<PublicacionPayload>(publicacion);

        }

        public async Task<bool> DeletePublication(Context context, int publicationId)
        {

            try
            {
                Publicacion? publicationExist = await context.Publicaciones.FindAsync(publicationId);

                if (publicationExist is null) return false;

                context.Publicaciones.Remove(publicationExist);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
