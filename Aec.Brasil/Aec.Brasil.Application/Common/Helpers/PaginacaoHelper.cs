using Aec.Brasil.Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Aec.Brasil.Application.Common.Helpers
{
    public static class PaginacaoHelper
    {
        public static PaginatedDto<T> Paginar<T>(IEnumerable<T> lista, int pagina, int linhas)
        {
            if (pagina <= 0 || linhas <= 0 || !lista.Any()) 
                return new PaginatedDto<T>() { Linhas = lista.Count(), Pagina = 1, TotalLinhas = lista.Count(), Registros = lista };

            var linhasIgnorar = (pagina - 1) * linhas;

            var registros = lista.Skip(linhasIgnorar).Take(linhas);

            return new PaginatedDto<T>() { Linhas = registros.Count(), Pagina = pagina, TotalLinhas = lista.Count(), Registros = registros };
        }
    }
}
