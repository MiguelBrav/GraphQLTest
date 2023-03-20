namespace GraphQLServer.Models
{
    public class Publicacion
    {

        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Contenido { get; set; } = null!;

        public string ImagenUrl { get; set; } = null!;

        public EstadoPublicacion Estado { get; set; }

        public int Rating { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; } = null!;

        public int AutorId   { get; set; }

        public Autor Autor { get; set; } = null!;
    }
}
