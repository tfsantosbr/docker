using System;
using System.Collections.Generic;
using Estoque.API.Data.Entities;

namespace Estoque.API.Data.Context
{
    public static class EstoqueDbContextExtensions
    {
        public static void SeedData(this EstoqueDbContext context)
        {
            context.Produtos.RemoveRange(context.Produtos);
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto
                {
                    Id = new Guid("a3c48fd6-c033-46bc-9b35-6d79b3fdb068"),
                    Nome = "Samsung Galaxy S8"
                },
                new Produto
                {
                    Id = new Guid("5b681648-348e-41b7-a565-3ddc591468f0"),
                    Nome = "Samsung Galaxy Note 8"
                },
                new Produto
                {
                    Id = new Guid("457cd0a7-7550-44c8-b5ad-a94852351031"),
                    Nome = "Apple Iphone X"
                }
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }
    }
}