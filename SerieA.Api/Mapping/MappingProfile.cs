using AutoMapper;
using SerieA.Api.Entities;
using SerieA.WebApi.DTOs.MatchCardDtos;
using SerieA.WebApi.DTOs.MatchDetailDtos;
using SerieA.WebApi.DTOs.MatchDtos;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.DTOs.MatchGoalDtos;
using SerieA.WebApi.DTOs.MatchStatisticDtos;
using SerieA.WebApi.DTOs.MatchSubstitutionDtos;
using SerieA.WebApi.DTOs.TeamDtos;
using SerieA.WebApi.Entities;

namespace SerieA.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTeamDto, Team>().ReverseMap();
            CreateMap<ResultTeamDto, Team>().ReverseMap(); 
            CreateMap<UpdateTeamDto, Team>().ReverseMap(); 

            CreateMap<CreateMatchDto, Match>().ReverseMap();
            CreateMap<Match, ResultMatchDto>().ReverseMap();
            CreateMap<UpdateMatchDto, Match>().ReverseMap();

            CreateMap<MatchGoal, ResultMatchGoalDto>().ReverseMap();
            CreateMap<MatchCard, ResultMatchCardDto>().ReverseMap();
            CreateMap<MatchSubstitution, ResultMatchSubstitutionDto>().ReverseMap();
            CreateMap<MatchStatistic, ResultMatchStatisticDto>().ReverseMap();

            CreateMap<Match, ResultMatchDetailDto>();

            CreateMap<CreateMatchEventDto, MatchGoal>();
            CreateMap<CreateMatchEventDto, MatchCard>();
            CreateMap<CreateMatchEventDto, MatchSubstitution>();
        }
    }
}
