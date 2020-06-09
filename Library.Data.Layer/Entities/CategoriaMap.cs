using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Data.EF.Entities
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria")
              .HasKey(c => c.Id);
            builder.Property(c => c.Nombre)
                .HasMaxLength(50);
            builder.Property(c => c.Descripcion)
                .HasMaxLength(256);
        }
    }
}
