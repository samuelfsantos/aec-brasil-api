using MediatR;
using Aec.Brasil.Application.Dtos;
using System.Collections.Generic;

namespace Aec.Brasil.Application.Queries.Cidade
{
    public class CidadeQuery : IRequest<List<CidadeDto>>
    {
        public int IdIntegracao { get; set; }
    }
}
