using System.Collections.Generic;
using System.Linq;
using cep.api.Data.Entities;

namespace cep.api.Data.Context
{
    public static class CepDbContextExtensions
    {
        public static void SeedData(this CepDbContext context)
        {
            context.Enderecos.RemoveRange(context.Enderecos);
            context.SaveChanges();

            if (!context.Estados.Any())
            {
                var estados = new List<Estado>
                {
                    new Estado
                    {
                        Sigla = "SP",
                        Nome = "São Paulo"
                    },
                    new Estado
                    {
                        Sigla = "RJ",
                        Nome = "Rio de Janeiro"
                    },
                    new Estado
                    {
                        Sigla = "ES",
                        Nome = "Espirito Santo"
                    },
                    new Estado
                    {
                        Sigla = "DF",
                        Nome = "Distrito Federal"
                    },
                    new Estado
                    {
                        Sigla = "BA",
                        Nome = "Bahia"
                    }
                };

                context.Estados.AddRange(estados);
                context.SaveChanges();
            }
        }
    }
}