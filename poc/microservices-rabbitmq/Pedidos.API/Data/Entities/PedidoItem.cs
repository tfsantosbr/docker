using System;

namespace Pedidos.API.Data.Entities
{
    public class PedidoItem
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Pedido Pedido { get; set; }
    }
}