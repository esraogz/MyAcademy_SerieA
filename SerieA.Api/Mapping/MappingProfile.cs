using AutoMapper;
using SerieA.Api.Entities;
using SerieA.WebApi.DTOs.TeamDtos;

namespace SerieA.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTeamDto, Team>().ReverseMap();
            CreateMap<ResultTeamDto, Team>().ReverseMap(); 
            CreateMap<UpdateTeamDto, Team>().ReverseMap(); 
        }
    }
}
