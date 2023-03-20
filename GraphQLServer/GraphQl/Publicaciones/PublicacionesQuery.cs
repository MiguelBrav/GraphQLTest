using GraphQLServer.Data;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.GraphQl.Publicaciones
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class PublicacionesQuery 
    {
        //Correct Order
        //[UsePaging(DefaultPageSize=3)] -- Alter pagination model
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Publicacion> GetPublicaciones(Context context)
        {
            return context.Publicaciones;
        }

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Publicacion> GetPublicacionById(Context context, int id)
        {
            return context.Publicaciones.Where(x => x.Id == id);
        }
    }
}
