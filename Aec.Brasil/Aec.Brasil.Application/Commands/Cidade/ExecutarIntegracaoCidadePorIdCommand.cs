using MediatR;
using System;

namespace Aec.Brasil.Application.Commands.Cidade
{
    public class ExecutarIntegracaoCidadePorIdCommand : IRequest<Guid>
    {
        public int IdIntegracao { get; set; }
    }
}
