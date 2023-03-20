using AutoMapper;
using GraphQLServer.Data;
using GraphQLServer.GraphQl.Types;
using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CategoriasMutation
    {
      
        public async Task<CategoriaPayload> CreateCategoria(Context context, CategoriaInputType inputCategory, [Service] IMapper mapper)
        {

            var category = mapper.Map<Categoria>(inputCategory);

            await context.Categorias.AddAsync(category);

            await context.SaveChangesAsync();

            return mapper.Map<CategoriaPayload>(category);

        }

        public async Task<CategoriaPayload> UpdateCategory(Context context, CategoriaInputType inputCategory, int categoryId, [Service] IMapper mapper)
        {

            var category = mapper.Map<Categoria>(inputCategory);
            category.Id = categoryId;

            context.Categorias.Update(category);

            await context.SaveChangesAsync();

            return mapper.Map<CategoriaPayload>(category);

        }

        public async Task<bool> DeleteCategory(Context context, int categoryId)
        {

            try
            {
                Categoria? categoryExist = await context.Categorias.FindAsync(categoryId);

                if (categoryExist is null) return false;

                context.Categorias.Remove(categoryExist);

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
