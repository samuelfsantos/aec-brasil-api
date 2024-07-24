using System.Text.Json.Serialization;

namespace Aec.Brasil.Application.Queries
{
    public abstract class PaginatedQuery
    {
        [JsonIgnore]
        public int NumeroPagina { get; set; }
        [JsonIgnore]
        public int NumeroLinhas { get; set; }
    }
}
