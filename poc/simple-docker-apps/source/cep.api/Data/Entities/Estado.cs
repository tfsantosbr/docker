using System.Collections.Generic;

namespace cep.api.Data.Entities
{
    public class Estado
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}