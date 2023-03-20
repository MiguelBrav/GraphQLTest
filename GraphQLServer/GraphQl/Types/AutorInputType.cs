using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Types
{
    public class AutorInputType
    {

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal Salario { get; set; }
              
    }
}
