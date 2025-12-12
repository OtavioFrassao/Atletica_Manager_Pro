using Atletica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atletica.Infrastructure.Data
{
    public class AtleticaDbContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<TarefaLimpeza> TarefasLimpeza { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public AtleticaDbContext(DbContextOptions<AtleticaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Cargo
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargos");
                entity.HasKey(c => c.Id);
                
                entity.Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(c => c.Descricao)
                    .HasMaxLength(255);

                // Relacionamento: Um Cargo tem muitos Membros
                entity.HasMany(c => c.Membros)
                    .WithOne(m => m.Cargo)
                    .HasForeignKey(m => m.CargoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração da entidade Membro
            modelBuilder.Entity<Membro>(entity =>
            {
                entity.ToTable("Membros");
                entity.HasKey(m => m.Id);
                
                entity.Property(m => m.Nome)
                    .IsRequired()
                    .HasMaxLength(150);
                
                entity.Property(m => m.Curso)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(m => m.Matricula)
                    .IsRequired()
                    .HasMaxLength(50);
                
                entity.Property(m => m.Contato)
                    .HasMaxLength(100);
                
                entity.Property(m => m.DataEntrada)
                    .IsRequired();

                // Relacionamento: Membro pertence a um Cargo
                entity.HasOne(m => m.Cargo)
                    .WithMany(c => c.Membros)
                    .HasForeignKey(m => m.CargoId);
            });

            // Configuração da entidade TarefaLimpeza
            modelBuilder.Entity<TarefaLimpeza>(entity =>
            {
                entity.ToTable("Limpezas");
                entity.HasKey(t => t.Id);
                
                entity.Property(t => t.Data)
                    .IsRequired();
                
                entity.Property(t => t.Descricao)
                    .IsRequired()
                    .HasColumnType("TEXT");
                
                entity.Property(t => t.Concluido)
                    .IsRequired()
                    .HasDefaultValue(false);

                // Relacionamento: TarefaLimpeza pertence a um Membro
                entity.HasOne(t => t.MembroResponsavel)
                    .WithMany()
                    .HasForeignKey(t => t.MembroResponsavelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração da entidade Evento
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Eventos");
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200);
                
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("TEXT");
                
                entity.Property(e => e.DataInicio)
                    .IsRequired();
                
                entity.Property(e => e.DataFim);
                
                entity.Property(e => e.Local)
                    .HasMaxLength(300);

                // Relacionamento: Evento pertence a um Membro (opcional)
                entity.HasOne(e => e.MembroResponsavel)
                    .WithMany()
                    .HasForeignKey(e => e.MembroResponsavelId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
