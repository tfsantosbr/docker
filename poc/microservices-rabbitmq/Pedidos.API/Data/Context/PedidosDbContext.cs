using Microsoft.EntityFrameworkCore;
using Pedidos.API.Data.Entities;

namespace Pedidos.API.Data.Context
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Pedido Configuration

            builder.Entity<Pedido>().HasKey(x => x.Id);

            // PedidoItens Configuration

            builder.Entity<PedidoItem>().HasKey(x => x.Id);
            builder.Entity<PedidoItem>().HasOne(x => x.Pedido).WithMany(x => x.Itens).HasForeignKey(x => x.PedidoId);
        }
    }
}