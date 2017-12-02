using System;
using System.Threading.Tasks;
using Estoque.API.Data.Context;
using Estoque.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estoque.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly EstoqueDbContext _estoqueDbContext;

        public ProdutosController(EstoqueDbContext estoqueDbContext)
        {
            _estoqueDbContext = estoqueDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            return Ok(await _estoqueDbContext.Produtos.ToListAsync());
        }

        [HttpGet("{produtoId:guid}")]
        public async Task<IActionResult> GetProdutoById(Guid produtoId)
        {
            var result = await _estoqueDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == produtoId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            _estoqueDbContext.Produtos.Add(produto);
            var result = await _estoqueDbContext.SaveChangesAsync();

            return result == 0 ? StatusCode(500) : Ok();
        }
    }
}