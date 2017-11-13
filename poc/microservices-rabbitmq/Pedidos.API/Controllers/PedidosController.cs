using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.API.Data.Context;
using Pedidos.API.Data.Entities;

namespace Pedidos.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidosController : Controller
    {
        private readonly PedidosDbContext _pedidosDbContext;

        public PedidosController(PedidosDbContext pedidosDbContext)
        {
            _pedidosDbContext = pedidosDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            return Ok(await _pedidosDbContext.Pedidos.Include(x=>x.Itens).ToListAsync());
        }

        [HttpGet("{pedidoId:guid}")]
        public async Task<IActionResult> GetPedidoById(Guid pedidoId)
        {
            var result = await _pedidosDbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == pedidoId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] Pedido pedido)
        {
            _pedidosDbContext.Pedidos.Add(pedido);
            var result = await _pedidosDbContext.SaveChangesAsync();

            return result == 0 ? StatusCode(500) : Ok();
        }
    }
}