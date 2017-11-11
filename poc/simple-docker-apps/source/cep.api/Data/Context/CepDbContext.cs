using cep.api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cep.api.Data.Context
{
    public class CepDbContext : DbContext
    {
        public CepDbContext(DbContextOptions<CepDbContext> options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Endereço Configuration

            builder.Entity<Endereco>().HasKey(x => x.Cep);
            builder.Entity<Endereco>().Property(x => x.Cep).IsRequired().HasColumnType("varchar(8)");
            builder.Entity<Endereco>().Property(x => x.Rua).IsRequired().HasColumnType("varchar(100)");
            builder.Entity<Endereco>().Property(x => x.Bairro).IsRequired().HasColumnType("varchar(40)");
            builder.Entity<Endereco>().Property(x => x.Uf).IsRequired().HasColumnType("varchar(2)");
            builder.Entity<Endereco>().Property(x => x.Numero).IsRequired().HasColumnType("varchar(5)");

            builder.Entity<Endereco>()
                .HasOne(x => x.Estado)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.Uf)
                .HasPrincipalKey(x => x.Sigla)
                .IsRequired();

            // Estado Configurations

            builder.Entity<Estado>().HasKey(x => x.Sigla);
            builder.Entity<Estado>().Property(x => x.Sigla).IsRequired().HasColumnType("varchar(2)");
            builder.Entity<Estado>().Property(x => x.Nome).IsRequired().HasColumnType("varchar(50)");
        }
    }
}