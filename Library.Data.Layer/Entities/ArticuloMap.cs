using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Library.Data.EF.Entities
{
    public class ArticuloMap : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("Articulo")
                .HasKey(a => a.Id);

            builder.HasOne(i => i.Categoria)
               .WithMany(p => p.Articulos)
               .HasForeignKey(i => i.Idcategoria);

            //builder.Property(e => e.Idcategoria).HasColumnName("idcategoria");





        }
    }
}
