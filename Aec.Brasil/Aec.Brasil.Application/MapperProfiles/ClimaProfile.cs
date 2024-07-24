using AutoMapper;
using Aec.Brasil.Application.Dtos;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Application.MapperProfiles
{
    public class ClimaProfile : Profile
    {
        public ClimaProfile()
        {
            CreateMap<Clima, ClimaDto>();
        }
    }
}
