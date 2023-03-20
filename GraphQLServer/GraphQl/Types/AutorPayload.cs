using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Types
{
    public class AutorPayload
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal Salario { get; set; }

        public ICollection<Publicacion> Publicaciones { get; set; } = null!;

    }
}
