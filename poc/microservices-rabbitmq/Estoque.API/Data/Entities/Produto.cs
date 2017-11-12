using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.API.Data.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
