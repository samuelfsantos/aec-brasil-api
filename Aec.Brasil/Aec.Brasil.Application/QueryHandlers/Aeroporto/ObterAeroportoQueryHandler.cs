using Aec.Brasil.Application.Dtos;
using Aec.Brasil.Application.Queries.Aeroporto;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Application.QueryHandlers.Aeroporto
{
    public class ObterAeroportoQueryHandler : CommandHandler, IRequestHandler<AeroportoQuery, List<AeroportoDto>>
    {
        private readonly IGenericRepository<Domain.Entities.Aeroporto> _genericRepository;
        private readonly IMapper _mapper;

        public ObterAeroportoQueryHandler(
            IGenericRepository<Domain.Entities.Aeroporto> genericRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IMediator mediator,
            INotificationDomain<NotificationDomainMessage> notifications)
            : base(uow, mediator, notifications)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public Task<List<AeroportoDto>> Handle(AeroportoQuery request, CancellationToken cancellationToken)
        {
            var aeroportos = string.IsNullOrEmpty(request.CodigoIcao)
                            ? _genericRepository.ObterTodos()
                            : _genericRepository.Consultar(x => x.CodigoIcao == request.CodigoIcao);

            aeroportos = OrdenarResultado(aeroportos);
            var result = _mapper.Map<List<AeroportoDto>>(aeroportos.ToList());

            return Task.FromResult(result);
        }

        private IQueryable<Domain.Entities.Aeroporto> OrdenarResultado(IQueryable<Domain.Entities.Aeroporto> result)
        {
            return result
                .OrderByDescending(x => x.CriadoEm)
                .ThenByDescending(x => x.AtualizadoEm);
        }

    }
}
