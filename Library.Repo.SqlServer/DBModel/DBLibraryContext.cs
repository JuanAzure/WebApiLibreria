using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Repo.SqlServer.DBModel
{
    public partial class DBLibraryContext : DbContext
    {
        public DBLibraryContext()
        {
        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetalleIngreso> DetalleIngreso { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Ingreso> Ingreso { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-C9HQICT\\MSSQLSERVER01;Database=DBLibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Idarticulo)
                    .HasName("PK__articulo__BCE2F8F78C7D6104");

                entity.ToTable("articulo");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__articulo__72AFBCC659ADD3A8")
                    .IsUnique();

                entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Condicion)
                    .HasColumnName("condicion")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioVenta)
                    .HasColumnName("precio_venta")
                    .HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Articulo)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__articulo__idcate__3D5E1FD2");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__categori__140587C72274FD04");

                entity.ToTable("categoria");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__categori__72AFBCC6AFB1660A")
                    .IsUnique();

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Condicion)
                    .HasColumnName("condicion")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleIngreso>(entity =>
            {
                entity.HasKey(e => e.IddetalleIngreso)
                    .HasName("PK__detalle___55124CDBEF4A36F0");

                entity.ToTable("detalle_ingreso");

                entity.Property(e => e.IddetalleIngreso).HasColumnName("iddetalle_ingreso");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");

                entity.Property(e => e.Idingreso).HasColumnName("idingreso");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdarticuloNavigation)
                    .WithMany(p => p.DetalleIngreso)
                    .HasForeignKey(d => d.Idarticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_i__idart__4D94879B");

                entity.HasOne(d => d.IdingresoNavigation)
                    .WithMany(p => p.DetalleIngreso)
                    .HasForeignKey(d => d.Idingreso)
                    .HasConstraintName("FK__detalle_i__iding__4CA06362");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IddetalleVenta)
                    .HasName("PK__detalle___5CEC1648E627EF1A");

                entity.ToTable("detalle_venta");

                entity.Property(e => e.IddetalleVenta).HasColumnName("iddetalle_venta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento)
                    .HasColumnName("descuento")
                    .HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdarticuloNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idarticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_v__idart__5535A963");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idventa)
                    .HasConstraintName("FK__detalle_v__idven__5441852A");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.Idingreso)
                    .HasName("PK__ingreso__60BD709AEE4A25B8");

                entity.ToTable("ingreso");

                entity.Property(e => e.Idingreso).HasColumnName("idingreso");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnName("fecha_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Impuesto)
                    .HasColumnName("impuesto")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NumComprobante)
                    .IsRequired()
                    .HasColumnName("num_comprobante")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerieComprobante)
                    .HasColumnName("serie_comprobante")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TipoComprobante)
                    .IsRequired()
                    .HasColumnName("tipo_comprobante")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.Idproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingreso__idprove__48CFD27E");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingreso__idusuar__49C3F6B7");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Idpersona)
                    .HasName("PK__persona__5C5C1E281C6CCEB1");

                entity.ToTable("persona");

                entity.Property(e => e.Idpersona).HasColumnName("idpersona");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumDocumento)
                    .HasColumnName("num_documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPersona)
                    .IsRequired()
                    .HasColumnName("tipo_persona")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__rol__24C6BB2033BD3161");

                entity.ToTable("rol");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Condicion)
                    .HasColumnName("condicion")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuario__080A9743F6077DF0");

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Condicion)
                    .HasColumnName("condicion")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumDocumento)
                    .HasColumnName("num_documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("password_hash")
                    .HasMaxLength(1);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("password_salt")
                    .HasMaxLength(1);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idrol__45F365D3");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__venta__F82D1AFB6923BDEB");

                entity.ToTable("venta");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnName("fecha_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Impuesto)
                    .HasColumnName("impuesto")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NumComprobante)
                    .IsRequired()
                    .HasColumnName("num_comprobante")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerieComprobante)
                    .HasColumnName("serie_comprobante")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TipoComprobante)
                    .IsRequired()
                    .HasColumnName("tipo_comprobante")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__idcliente__5070F446");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__idusuario__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
