using AutoMapper;
using MediatR;
using Aec.Brasil.Application.Dtos;
using Aec.Brasil.Application.Queries.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.QueryHandlers.Cidade
{
    public class ObterCidadeQueryHandler : CommandHandler, IRequestHandler<CidadeQuery, List<CidadeDto>>
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public ObterCidadeQueryHandler(
            ICidadeRepository cidadeRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IMediator mediator,
            INotificationDomain<NotificationDomainMessage> notifications)
            : base(uow, mediator, notifications)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public Task<List<CidadeDto>> Handle(CidadeQuery request, CancellationToken cancellationToken)
        {
            var cidades = _cidadeRepository.ObterPorIdIntegracaoComClimas(request.IdIntegracao);

            cidades = OrdenarResultado(cidades);
            var result = _mapper.Map<List<CidadeDto>>(cidades.ToList());

            return Task.FromResult(result);
        }

        private IQueryable<Domain.Entities.Cidade> OrdenarResultado(IQueryable<Domain.Entities.Cidade> result)
        {
            return result.OrderByDescending(x => x.CriadoEm).ThenByDescending(x => x.AtualizadoEm);
        }

    }
}
