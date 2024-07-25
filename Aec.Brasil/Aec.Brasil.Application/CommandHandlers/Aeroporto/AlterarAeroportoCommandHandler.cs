using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Aeroporto;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.CommandHandlers.Aeroporto
{
    public class AlterarAeroportoCommandHandler : CommandHandler, IRequestHandler<AlteracaoAeroportoCommand, Unit>
    {
        private readonly IAeroportoAlteracaoValidator _aeroportoAlteracaoValidator;
        private readonly IGenericRepository<Domain.Entities.Aeroporto> _genericRepository;

        public AlterarAeroportoCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                IAeroportoAlteracaoValidator aeroportoAlteracaoValidator,
                IGenericRepository<Domain.Entities.Aeroporto> genericRepository,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _aeroportoAlteracaoValidator = aeroportoAlteracaoValidator;
            _genericRepository = genericRepository;
        }

        public Task<Unit> Handle(AlteracaoAeroportoCommand request, CancellationToken cancellationToken)
        {
            var aeroporto = _genericRepository.Consultar(x => x.Id == request.IdAeroporto).FirstOrDefault();

            if (aeroporto == null)
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado um aeroporto para o id informado."));
            else
            {
                aeroporto.CodigoIcao = request.CodigoIcao ?? aeroporto.CodigoIcao;
                aeroporto.Umidade = request.Umidade ?? aeroporto.Umidade;
                aeroporto.Visibilidade = request.Visibilidade ?? aeroporto.Visibilidade;
                aeroporto.PressaoAtmosferica = request.PressaoAtmosferica ?? aeroporto.PressaoAtmosferica;
                aeroporto.Vento = request.Vento ?? aeroporto.Vento;
                aeroporto.DirecaoVento = request.DirecaoVento ?? aeroporto.DirecaoVento;
                aeroporto.Condicao = request.Condicao ?? aeroporto.Condicao;
                aeroporto.CondicaoDesc = request.CondicaoDesc ?? aeroporto.CondicaoDesc;
                aeroporto.Temp = request.Temp ?? aeroporto.Temp;
                aeroporto.AtualizadoEm = request.AtualizadoEm ?? aeroporto.AtualizadoEm;

                aeroporto.GerarDadosControleAlteracao("usuario.generico");

                NotificarErros(_aeroportoAlteracaoValidator.Validar(aeroporto));

                if (IsSuccess())
                {
                    _genericRepository.Modificar(aeroporto);

                    Commit();
                }
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
