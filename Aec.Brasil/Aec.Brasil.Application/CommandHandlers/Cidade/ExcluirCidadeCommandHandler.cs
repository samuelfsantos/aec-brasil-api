using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aec.Brasil.Domain.Repositories;

namespace Aec.Brasil.Application.CommandHandlers.Cidade
{
    public class ExcluirCidadeCommandHandler : CommandHandler, IRequestHandler<ExclusaoCidadeCommand, Unit>
    {
        private readonly IGenericRepository<Domain.Entities.Cidade> _genericRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IGenericRepository<Domain.Entities.Clima> _climaGenericRepository;

        public ExcluirCidadeCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                IGenericRepository<Domain.Entities.Cidade> genericRepository,
                ICidadeRepository cidadeRepository,
                IGenericRepository<Domain.Entities.Clima> climaGenericRepository,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _genericRepository = genericRepository;
            _cidadeRepository = cidadeRepository;
            _climaGenericRepository = climaGenericRepository;
        }

        public Task<Unit> Handle(ExclusaoCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = _cidadeRepository.ObterPorIdComClimas(request.IdCidade);
            if (cidade == null)
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado uma cidade para o id informado."));
            else
            {
                foreach (var clima in cidade?.Climas)
                    _climaGenericRepository.Remover(clima);

                _genericRepository.Remover(cidade);

                Commit();
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
