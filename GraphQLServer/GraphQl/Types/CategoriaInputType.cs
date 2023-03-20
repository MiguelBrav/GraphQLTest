using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Types
{
    public class CategoriaInputType
    {

        public string Nombre { get; set; } = null!;

        public ICollection<Publicacion> Publicaciones { get; set; } = null!;

    }
}
