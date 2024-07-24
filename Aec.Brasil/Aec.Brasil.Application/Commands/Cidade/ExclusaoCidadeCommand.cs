using MediatR;
using System;

namespace Aec.Brasil.Application.Commands.Cidade
{
    public class ExclusaoCidadeCommand : IRequest<Unit>
    {
        public Guid IdCidade { get; set; }
    }
}
