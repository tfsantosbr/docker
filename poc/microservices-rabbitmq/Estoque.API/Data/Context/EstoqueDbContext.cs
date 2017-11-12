using Estoque.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estoque.API.Data.Context
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Produto Configuration

            builder.Entity<Produto>().HasKey(x => x.Id);
            builder.Entity<Produto>().Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
        }
    }
}