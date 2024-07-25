using MediatR;
using Aec.Brasil.Application.Dtos;
using System.Collections.Generic;

namespace Aec.Brasil.Application.Queries.Aeroporto
{
    public class AeroportoQuery : IRequest<List<AeroportoDto>>
    {
        public string CodigoIcao { get; set; }
    }
}
