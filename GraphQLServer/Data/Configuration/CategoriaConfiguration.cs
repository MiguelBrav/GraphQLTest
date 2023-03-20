using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLServer.Data.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria", "bg");

            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(200);

            builder.HasMany(u => u.Publicaciones).WithOne(u => u.Categoria).HasForeignKey(u => u.CategoriaId);

        }
    }
}
