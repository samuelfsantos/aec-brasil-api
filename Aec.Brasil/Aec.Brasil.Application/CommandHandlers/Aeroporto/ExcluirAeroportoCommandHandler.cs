using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.CommandHandlers.Aeroporto
{
    public class ExcluirAeroportoCommandHandler : CommandHandler, IRequestHandler<ExclusaoAeroportoCommand, Unit>
    {
        private readonly IGenericRepository<Domain.Entities.Aeroporto> _genericRepository;

        public ExcluirAeroportoCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                IGenericRepository<Domain.Entities.Aeroporto> genericRepository,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _genericRepository = genericRepository;
        }

        public Task<Unit> Handle(ExclusaoAeroportoCommand request, CancellationToken cancellationToken)
        {
            var aeroporto = _genericRepository.Consultar(x => x.Id == request.IdAeroporto).FirstOrDefault();
            if (aeroporto == null)
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado um aeroporto para o id informado."));
            else
            {
                _genericRepository.Remover(aeroporto);

                Commit();
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
