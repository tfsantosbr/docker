using System;
using System.Text;
using System.Threading.Tasks;
using Estoque.API.Data.Context;
using Estoque.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Logging;

namespace Estoque.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly EstoqueDbContext _estoqueDbContext;
        private readonly ILogger _logger;

        public ProdutosController(EstoqueDbContext estoqueDbContext, ILogger<ProdutosController> logger)
        {
            _estoqueDbContext = estoqueDbContext;
            _logger = logger;
            RegistraHandlerMensagensProdutos();
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

        private void RegistraHandlerMensagensProdutos()
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq", UserName = "developer", Password = "developer" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "pedidos", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        _logger.LogWarning($"Mensagem recebida: {message}");

                    };
                    channel.BasicConsume(queue: "pedidos", autoAck: true, consumer: consumer);
                    _logger.LogWarning("Ouvindo mensagens da vilda de pedidos");

                }
            }
        }
    }
}