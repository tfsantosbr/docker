using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.API.Data.Context;
using Pedidos.API.Data.Entities;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

namespace Pedidos.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidosController : Controller
    {
        private readonly PedidosDbContext _pedidosDbContext;
        private readonly ILogger _logger;

        public PedidosController(PedidosDbContext pedidosDbContext, ILogger<PedidosController> logger)
        {
            _pedidosDbContext = pedidosDbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            return Ok(await _pedidosDbContext.Pedidos.Include(x => x.Itens).ToListAsync());
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
            pedido.Id = Guid.NewGuid();
            pedido.Data = DateTime.Now;

            foreach (var pedidoItem in pedido.Itens)
            {
                pedidoItem.Id = Guid.NewGuid();
                pedidoItem.PedidoId = pedido.Id;
            }

            _pedidosDbContext.Pedidos.Add(pedido);
            var result = await _pedidosDbContext.SaveChangesAsync();

            if (result > 0)
            {
                EnviaMensagemPedidoCriado();
            }

            return result == 0 ? StatusCode(500) : Ok();
        }

        private void EnviaMensagemPedidoCriado()
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq", UserName = "developer", Password = "developer" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "pedidos", durable: false, exclusive: false, autoDelete: false, arguments: null);

                const string message = "PedidoCriado";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "pedidos", basicProperties: null, body: body);

                _logger.LogWarning($"Mensagem enviada: {message}");
            }
        }
    }
}