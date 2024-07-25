using MediatR;
using System;

namespace Aec.Brasil.Application.Commands.Aeroporto
{
    public class ExclusaoAeroportoCommand : IRequest<Unit>
    {
        public Guid IdAeroporto { get; set; }
    }
}
