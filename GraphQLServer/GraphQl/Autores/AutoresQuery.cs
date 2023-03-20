using GraphQLServer.Data;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AutoresQuery
    {
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Autor> GetAutores(Context context)
        {
            return context.Autores;
        }

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Autor> GetAutorById(Context context, int id)
        {
            return context.Autores.Where(x => x.Id == id);
        }
    }
}
