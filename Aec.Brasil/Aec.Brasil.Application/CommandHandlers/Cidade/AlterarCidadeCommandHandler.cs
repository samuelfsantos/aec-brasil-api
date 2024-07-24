using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Cidade;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.CommandHandlers.Cidade
{
    public class AlterarCidadeCommandHandler : CommandHandler, IRequestHandler<AlteracaoCidadeCommand, Unit>
    {
        private readonly ICidadeAlteracaoValidator _cidadeAlteracaoValidator;
        private readonly IGenericRepository<Domain.Entities.Cidade> _genericRepository;

        public AlterarCidadeCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                ICidadeAlteracaoValidator cidadeAlteracaoValidator,
                IGenericRepository<Domain.Entities.Cidade> genericRepository,
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _cidadeAlteracaoValidator = cidadeAlteracaoValidator;
            _genericRepository = genericRepository;
        }

        public Task<Unit> Handle(AlteracaoCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = _genericRepository.Consultar(x => x.Id == request.IdCidade).FirstOrDefault();

            if (cidade == null)
                _notifications.Add(new NotificationDomainMessage("Não foi encontrado uma cidade para o id informado."));
            else
            {
                cidade.IdIntegracao = request.IdIntegracao ?? cidade.IdIntegracao;
                cidade.Nome = request.Nome ?? cidade.Nome;
                cidade.Estado = request.Estado ?? cidade.Estado;
                cidade.AtualizadoEm = request.AtualizadoEm ?? cidade.AtualizadoEm;

                cidade.GerarDadosControleAlteracao("usuario.generico");

                NotificarErros(_cidadeAlteracaoValidator.Validar(cidade));

                if (IsSuccess())
                {
                    _genericRepository.Modificar(cidade);

                    Commit();
                }
            }

            return Task.FromResult(Unit.Value);
        }

    }
}
