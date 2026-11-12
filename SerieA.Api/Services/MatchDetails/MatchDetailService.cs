using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.MatchDetailDtos;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.Exceptions;

namespace SerieA.WebApi.Services.MatchDetails
{
    public class MatchDetailService(AppDbContext _context,
                                    IMapper _mapper) : IMatchDetailService
    {

        public async Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id)
        {
            var value = await _context.Matches.Include(x => x.HomeTeam)
                                              .Include(x => x.AwayTeam)
                                              .Include(x => x.MatchGoals)
                                              .Include(x => x.MatchCards)
                                              .Include(x => x.MatchSubstitutions)
                                              .Include(x => x.MatchStatistic)
                                              .FirstOrDefaultAsync(x => x.MatchId == id);

            if (value == null)
            {
                throw new NotFoundException($"{id} ID'sine sahip bir maç bulunamadı.");
            }

            var detailDto = _mapper.Map<ResultMatchDetailDto>(value);
            return detailDto;
        }
    }
}
