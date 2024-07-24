using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Validators.Cidade;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.CommandHandlers.Cidade
{
    public class CriarCidadeCommandHandler : CommandHandler, IRequestHandler<CriacaoCidadeCommand, Guid>
    {
        private readonly ICidadeCriacaoValidator _cidadeCriacaoValidator;
        private readonly IGenericRepository<Domain.Entities.Cidade> _genericRepository;        

        public CriarCidadeCommandHandler(
                IUnitOfWork uow,
                IMediator mediator,
                ICidadeCriacaoValidator cidadeCriacaoValidator,
                IGenericRepository<Domain.Entities.Cidade> genericRepository,                
                INotificationDomain<NotificationDomainMessage> notifications)
                : base(uow, mediator, notifications)
        {
            _cidadeCriacaoValidator = cidadeCriacaoValidator;
            _genericRepository = genericRepository;
        }

        public Task<Guid> Handle(CriacaoCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = new Domain.Entities.Cidade("usuario.generico");
            cidade.Id = Guid.NewGuid();
            cidade.IdIntegracao = request.IdIntegracao;
            cidade.Nome = request.Nome;
            cidade.Estado = request.Estado;
            cidade.AtualizadoEm = request.AtualizadoEm;

            NotificarErros(_cidadeCriacaoValidator.Validar(cidade));

            if (!IsSuccess())
                return Task.FromResult(Guid.Empty);

            _genericRepository.Adicionar(cidade);
            Commit();

            return Task.FromResult(cidade.Id);
        }

    }
}
