using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiTecnotienda.Models
{
    public partial class BDTecnotiendaContext : DbContext
    {
        public BDTecnotiendaContext()
        {
        }

        public BDTecnotiendaContext(DbContextOptions<BDTecnotiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BTLG386;Initial Catalog=BDTecnotienda;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__5EEC79D15A0C6794");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("precio");

                entity.Property(e => e.Stock)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("stock");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__UserTabl__3717C982C1E6C489");

                entity.ToTable("UserTable");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.PasswordData)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passwordData");

                entity.Property(e => e.UserData)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userData");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
