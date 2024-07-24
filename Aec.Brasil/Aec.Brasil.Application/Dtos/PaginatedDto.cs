using System.Collections.Generic;

namespace Aec.Brasil.Application.Dtos
{
    public class PaginatedDto<T>
    {
        public int Pagina { get; set; }
        public int Linhas { get; set; }
        public int TotalLinhas { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}
