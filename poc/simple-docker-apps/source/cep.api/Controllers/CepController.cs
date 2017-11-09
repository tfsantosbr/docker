using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cep.api.Controllers
{
    [Route("api/cep")]
    public class CepController : Controller
    {
        [HttpGet("{codigo}")]
        public IActionResult Get(string codigo)
        {
            if (codigo == "123456")
            {
                return Ok(new
                {
                    rua = "Rua A",
                    numero = 123,
                    bairro = "Bairro A",
                    cep = "123456"
                });
            }

            if (codigo == "654321")
            {
                return Ok(new
                {
                    rua = "Rua B",
                    numero = 321,
                    bairro = "Bairro B",
                    cep = "654321"
                });
            }

            return NotFound();
        }
    }
}
