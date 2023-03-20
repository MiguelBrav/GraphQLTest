namespace GraphQLServer.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public ICollection<Publicacion> Publicaciones { get; set; } = null!;
    }
}
