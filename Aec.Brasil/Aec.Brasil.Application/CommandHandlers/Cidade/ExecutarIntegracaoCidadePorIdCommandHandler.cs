using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Cidade;
using System;
using System.Threading;
using System.Threading.Tasks;
using Aec.Brasil.Domain.Services;
using Aec.Brasil.Domain.Validators.Clima;

namespace Aec.Brasil.Application.CommandHandlers.Cidade
{
    public class ExecutarIntegracaoCidadePorIdCommandHandler : CommandHandler, IRequestHandler<ExecutarIntegracaoCidadePorIdCommand, Guid>
    {
        private readonly ICidadeCriacaoValidator _cidadeCriacaoValidator;
        private readonly IClimaCriacaoValidator _climaCriacaoValidator;
        private readonly IGenericRepository<Domain.Entities.Cidade> _genericRepository;
        private readonly IBrasilApiService _brasilApiService;

        public ExecutarIntegracaoCidadePorIdCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                ICidadeCriacaoValidator cidadeCriacaoValidator,
                IClimaCriacaoValidator climaCriacaoValidator,
                IGenericRepository<Domain.Entities.Cidade> genericRepository,
                IBrasilApiService brasilApiService,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _cidadeCriacaoValidator = cidadeCriacaoValidator;
            _climaCriacaoValidator = climaCriacaoValidator;
            _genericRepository = genericRepository;
            _brasilApiService = brasilApiService;
        }

        public Task<Guid> Handle(ExecutarIntegracaoCidadePorIdCommand request, CancellationToken cancellationToken)
        {
            var cidade = _brasilApiService.ObterCidadePorId(request.IdIntegracao);

            if (cidade == null)
            {
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado uma cidade para o id informado."));

                return Task.FromResult(Guid.Empty);
            }
            else
            {
                NotificarErros(_cidadeCriacaoValidator.Validar(cidade));

                foreach (var clima in cidade.Climas)
                    NotificarErros(_climaCriacaoValidator.Validar(clima));

                if (!IsSuccess())
                    return Task.FromResult(Guid.Empty);

                _genericRepository.Adicionar(cidade);

                Commit();

                return Task.FromResult(cidade.Id);
            }            
        }

    }
}
