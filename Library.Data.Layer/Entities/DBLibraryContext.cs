using Microsoft.EntityFrameworkCore;

namespace Library.Data.EF.Entities
{
    public partial class DBLibraryContext : DbContext
    {

        public DBLibraryContext()
        {

        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options) : base(options)
        {

        }
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}