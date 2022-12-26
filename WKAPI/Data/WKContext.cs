using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WKAPI.Models;

namespace WKAPI.Data
{
    public partial class WKContext : DbContext
    {
        public WKContext()
        {
        }

        public WKContext(DbContextOptions<WKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.HasIndex(e => e.Idcategoria, "FK_Produto_Categoria_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Produto_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
