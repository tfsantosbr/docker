using System;
using System.Collections.Generic;
using Pedidos.API.Data.Entities;

namespace Pedidos.API.Data.Context
{
    public static class PedidosDbContextExtensions
    {
        public static void SeedData(this PedidosDbContext context)
        {
            context.PedidoItens.RemoveRange(context.PedidoItens);
            context.Pedidos.RemoveRange(context.Pedidos);
            context.SaveChanges();

            var pedidos = new List<Pedido>
            {
                new Pedido
                {
                    Id = new Guid("bccc6f88-c6db-4bea-8cbb-d5fe0ba6e9d2"),
                    Cliente = "Tiago Santos",
                    Data = DateTime.Now,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem
                        {
                            Id = new Guid("f0a479fb-7f0f-4b80-8edd-51df9779932f"),
                            PedidoId = new Guid("bccc6f88-c6db-4bea-8cbb-d5fe0ba6e9d2"),
                            ProdutoId = new Guid("a3c48fd6-c033-46bc-9b35-6d79b3fdb068"),
                            Quantidade = 1,
                            Valor = 500m
                        },
                        new PedidoItem
                        {
                            Id = new Guid("70b57e00-b847-4050-ad2b-4d0230cb0470"),
                            PedidoId = new Guid("bccc6f88-c6db-4bea-8cbb-d5fe0ba6e9d2"),
                            ProdutoId = new Guid("5b681648-348e-41b7-a565-3ddc591468f0"),
                            Quantidade = 1,
                            Valor = 800m
                        }
                    }
                }
            };

            context.Pedidos.AddRange(pedidos);
            context.SaveChanges();
        }
    }
}