using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Aec.Brasil.Application.Commands.Cidade
{
    public class AlteracaoCidadeCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid IdCidade { get; set; }
        public int? IdIntegracao { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
