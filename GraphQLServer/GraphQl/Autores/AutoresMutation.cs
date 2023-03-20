using AutoMapper;
using GraphQLServer.Data;
using GraphQLServer.GraphQl.Types;
using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AutoresMutation
    {
      
        public async Task<AutorPayload> CreateAutor(Context context, AutorInputType inputAutor, [Service] IMapper mapper)
        {

            var autor = mapper.Map<Autor>(inputAutor);

            await context.Autores.AddAsync(autor);

            await context.SaveChangesAsync();

            return mapper.Map<AutorPayload>(autor);

        }

        public async Task<AutorPayload> UpdateAutor(Context context, AutorInputType inputAutor, int autorId, [Service] IMapper mapper)
        {

            var autor = mapper.Map<Autor>(inputAutor);

            autor.Id = autorId;

            context.Autores.Update(autor);

            await context.SaveChangesAsync();

            return mapper.Map<AutorPayload>(autor);

        }

        public async Task<bool> DeleteAutor(Context context, int autorId)
        {

            try
            {
                Autor? autorExist = await context.Autores.FindAsync(autorId);

                if (autorExist is null) return false;

                context.Autores.Remove(autorExist);

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
