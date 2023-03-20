﻿using GraphQLServer.Models;

namespace GraphQLServer.GraphQl.Types
{
    public class CategoriaPayload
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public ICollection<Publicacion> Publicaciones { get; set; } = null!;
    }
}
