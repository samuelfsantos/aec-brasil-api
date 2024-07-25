using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Aec.Brasil.Application.Commands.Aeroporto
{
    public class AlteracaoAeroportoCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid IdAeroporto { get; set; }
        public string CodigoIcao { get; set; }
        public int? Umidade { get; set; }
        public string Visibilidade { get; set; }
        public int? PressaoAtmosferica { get; set; }
        public int? Vento { get; set; }
        public int? DirecaoVento { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int? Temp { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
