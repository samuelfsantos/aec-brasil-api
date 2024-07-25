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
using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Domain.Validators.Aeroporto;

namespace Aec.Brasil.Application.CommandHandlers.Aeroporto
{
    public class ExecutarIntegracaoAeroportoPorIdCommandHandler : CommandHandler, IRequestHandler<ExecutarIntegracaoAeroportoPorIdCommand, Guid>
    {
        private readonly IAeroportoCriacaoValidator _aeroportoCriacaoValidator;
        private readonly IGenericRepository<Domain.Entities.Aeroporto> _genericRepository;
        private readonly IBrasilApiService _brasilApiService;

        public ExecutarIntegracaoAeroportoPorIdCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                IAeroportoCriacaoValidator aeroportoCriacaoValidator,
                IGenericRepository<Domain.Entities.Aeroporto> genericRepository,
                IBrasilApiService brasilApiService,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _aeroportoCriacaoValidator = aeroportoCriacaoValidator;
            _genericRepository = genericRepository;
            _brasilApiService = brasilApiService;
        }

        public Task<Guid> Handle(ExecutarIntegracaoAeroportoPorIdCommand request, CancellationToken cancellationToken)
        {
            var aeroporto = _brasilApiService.ObterAeroportoPorCodigo(request.CodigoIcao);

            if (aeroporto == null)
            {
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado um aeroporto para o codigo icao informado."));

                return Task.FromResult(Guid.Empty);
            }
            else
            {
                NotificarErros(_aeroportoCriacaoValidator.Validar(aeroporto));

                if (!IsSuccess())
                    return Task.FromResult(Guid.Empty);

                _genericRepository.Adicionar(aeroporto);

                Commit();

                return Task.FromResult(aeroporto.Id);
            }            
        }

    }
}
