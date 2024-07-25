using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Aeroporto;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.CommandHandlers.Aeroporto
{
    public class CriarAeroportoCommandHandler : CommandHandler, IRequestHandler<CriacaoAeroportoCommand, Guid>
    {
        private readonly IAeroportoCriacaoValidator _aeroportoCriacaoValidator;
        private readonly IGenericRepository<Domain.Entities.Aeroporto> _genericRepository;        

        public CriarAeroportoCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                IAeroportoCriacaoValidator aeroportoCriacaoValidator,
                IGenericRepository<Domain.Entities.Aeroporto> genericRepository,                
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _aeroportoCriacaoValidator = aeroportoCriacaoValidator;
            _genericRepository = genericRepository;
        }

        public Task<Guid> Handle(CriacaoAeroportoCommand request, CancellationToken cancellationToken)
        {
            var aeroporto = new Domain.Entities.Aeroporto("usuario.generico");
            aeroporto.Id = Guid.NewGuid();
            aeroporto.CodigoIcao = request.CodigoIcao;
            aeroporto.Umidade = request.Umidade;
            aeroporto.Visibilidade = request.Visibilidade;
            aeroporto.PressaoAtmosferica = request.PressaoAtmosferica;
            aeroporto.Vento = request.Vento;
            aeroporto.DirecaoVento = request.DirecaoVento;
            aeroporto.Condicao = request.Condicao;
            aeroporto.CondicaoDesc = request.CondicaoDesc;
            aeroporto.Temp = request.Temp;
            aeroporto.AtualizadoEm = request.AtualizadoEm;

            NotificarErros(_aeroportoCriacaoValidator.Validar(aeroporto));

            if (!IsSuccess())
                return Task.FromResult(Guid.Empty);

            _genericRepository.Adicionar(aeroporto);
            Commit();

            return Task.FromResult(aeroporto.Id);
        }

    }
}
