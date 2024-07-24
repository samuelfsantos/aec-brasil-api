using MediatR;
using System;

namespace Aec.Brasil.Application.Commands.Cidade
{
    public class CriacaoCidadeCommand : IRequest<Guid>
    {
        public int IdIntegracao { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
