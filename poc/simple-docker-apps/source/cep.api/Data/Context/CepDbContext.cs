using cep.api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace cep.api.Data.Context
{
    public class CepDbContext : DbContext
    {
        public CepDbContext(DbContextOptions<CepDbContext> options) :base(options)
        {
        }
 
        public DbSet<Endereco> Enderecos { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}