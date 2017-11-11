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
    [Route("api/estados")]
    public class EstadosController : Controller
    {
        private CepDbContext _context;

        public EstadosController(CepDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetEstados()
        {
            var estados = await _context.Estados.OrderBy(x => x.Sigla).ToListAsync();

            if (estados == null)
                return NotFound();

            return Ok(estados);
        }
    }
}
