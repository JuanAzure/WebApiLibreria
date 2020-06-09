using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Repo.SqlServer.DBModelCliente
{
    public partial class RestauranntDBContext : DbContext
    {
        //public RestauranntDBContext()
        //{
        //}

        public RestauranntDBContext(DbContextOptions<RestauranntDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CliDirecciones> CliDirecciones { get; set; }
        public virtual DbSet<CliTelefonos> CliTelefonos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=DESKTOP-C9HQICT\MSSQLSERVER01;Database=RestauranntDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CliDirecciones>(entity =>
            {
                entity.ToTable("cli_direcciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.CliDirecciones)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK_cli_direcciones_clientes");
            });

            modelBuilder.Entity<CliTelefonos>(entity =>
            {
                entity.ToTable("cli_telefonos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.CliTelefonos)
                    .HasForeignKey(d => d.Idcliente)
               //     .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_cli_telefonos_clientes");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fechadenacimiento)
                    .HasColumnName("fechadenacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
   
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Gtotal)
                    .HasColumnName("GTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pmethod)
                    .HasColumnName("PMethod")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_OrderItems_Item");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItems_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
