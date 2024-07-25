
namespace Aec.Brasil.Services.BrasilApi.Models
{
    public class CidadeBrasilApi
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public DateTime atualizado_em { get; set; }
        public List<ClimaBrasilApi> clima { get; set; }
    }
}
