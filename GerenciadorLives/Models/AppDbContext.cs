using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciadorLives.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inscricoes> Inscricoes { get; set; }
        public virtual DbSet<Inscritos> Inscritos { get; set; }
        public virtual DbSet<Instrutores> Instrutores { get; set; }
        public virtual DbSet<Lives> Lives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3RG86U2;Initial Catalog=GerenciadorLives;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscricoes>(entity =>
            {
                entity.HasKey(e => e.InscricaoId);

                entity.HasIndex(e => e.InscritoId);

                entity.HasIndex(e => e.LiveId);

                entity.Property(e => e.Boleto).HasColumnName("boleto");

                entity.HasOne(d => d.Inscrito)
                    .WithMany(p => p.Inscricoes)
                    .HasForeignKey(d => d.InscritoId);

                entity.HasOne(d => d.Live)
                    .WithMany(p => p.Inscricoes)
                    .HasForeignKey(d => d.LiveId);
            });

            modelBuilder.Entity<Inscritos>(entity =>
            {
                entity.HasKey(e => e.InscritoId);
            });

            modelBuilder.Entity<Instrutores>(entity =>
            {
                entity.HasKey(e => e.InstrutorId);

                entity.Property(e => e.InstrutorId).HasColumnName("InstrutorID");
            });

            modelBuilder.Entity<Lives>(entity =>
            {
                entity.HasKey(e => e.LiveId);

                entity.HasIndex(e => e.InstrutorId);

                entity.HasOne(d => d.Instrutor)
                    .WithMany(p => p.Lives)
                    .HasForeignKey(d => d.InstrutorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
