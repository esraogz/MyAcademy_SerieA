using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.MatchDetailDtos;

namespace SerieA.WebApi.Services.MatchDetails
{
    public class MatchDetailService(AppDbContext _context,
                                    IMapper _mapper) : IMatchDetailService
    {
        public async Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id)
        {
            var value = await _context.Matches.Include(x => x.HomeTeam)
                                              .Include(x => x.AwayTeam)
                                              .FirstOrDefaultAsync(x => x.MatchId == id);
            var detailDto = _mapper.Map<ResultMatchDetailDto>(value); 
            
            return detailDto;
        }
    }
}
