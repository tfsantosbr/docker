using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cep.api.Data.Context;
using cep.api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cep.api.Controllers
{
    [Route("api/enderecos")]
    public class EnderecosController : Controller
    {
        private CepDbContext _context;

        public EnderecosController(CepDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnderecos(string cep)
        {
            var enderecos = await _context.Enderecos.ToListAsync();

            if (enderecos == null)
                return NotFound();

            return Ok(enderecos);
        }

        [HttpGet("{cep}", Name = "GetEndereco")]
        public async Task<IActionResult> GetEnderecoByCep(string cep)
        {
            var enderecos = await _context.Enderecos.FirstOrDefaultAsync(x => x.Cep == cep);

            if (enderecos == null)
                return NotFound();

            return Ok(enderecos);
        }

        [HttpPost]
        public async Task<IActionResult> PostEndereco([FromBody] Endereco endereco)
        {
            if (_context.Enderecos.Any(x => x.Cep == endereco.Cep))
                return BadRequest("Endereço já cadastrado");

            if (!_context.Estados.Any(x => x.Sigla == endereco.Uf))
                return BadRequest("Estado não encontrado");

            await _context.Enderecos.AddAsync(endereco);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return BadRequest();

            return CreatedAtRoute("GetEndereco", new { cep = endereco.Cep }, endereco);
        }
    }
}
