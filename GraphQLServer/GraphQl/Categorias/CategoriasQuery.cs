using GraphQLServer.Data;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CategoriasQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Categoria> GetCategorias(Context context)
        {
            return context.Categorias;
        }

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Categoria> GetCategoriaById(Context context, int id)
        {
            return context.Categorias.Where(x => x.Id == id);
        }
    }
}
