using System;
using System.Collections;
using System.Collections.Generic;

namespace Pedidos.API.Data.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Data { get; set; }

        public ICollection<PedidoItem> Itens { get; set; }
    }
}