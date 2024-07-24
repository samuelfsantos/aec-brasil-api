using AutoMapper;
using Aec.Brasil.Application.Dtos;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Application.MapperProfiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<Cidade, CidadeDto>();
        }
    }
}
