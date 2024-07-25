using MediatR;
using System;

namespace Aec.Brasil.Application.Commands.Aeroporto
{
    public class ExecutarIntegracaoAeroportoPorIdCommand : IRequest<Guid>
    {
        public string CodigoIcao { get; set; }
    }
}
