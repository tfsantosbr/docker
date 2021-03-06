using System.ComponentModel.DataAnnotations;

namespace cep.api.Data.Entities
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Uf { get; set; }
        public Estado Estado { get; set; }
    }
}