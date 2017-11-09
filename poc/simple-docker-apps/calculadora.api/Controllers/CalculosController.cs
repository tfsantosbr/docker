using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace calculadora.api.Controllers
{
    [Route("api/calculos")]
    public class CalculosController : Controller
    {
        [HttpGet("somar/{a:int}/{b:int}")]
        public IActionResult Somar(int a, int b)
        {
            return Ok(a + b);
        }

        [HttpGet("subtrair/{a:int}/{b:int}")]
        public IActionResult Subtrair(int a, int b)
        {
            return Ok(a - b);
        }
    }
}
