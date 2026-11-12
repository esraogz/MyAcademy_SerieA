using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.MatchDtos;
using SerieA.WebApi.Exceptions;

namespace SerieA.WebApi.Services.Matches
{
    public class MatchService(AppDbContext _context,
                              IMapper _mapper) : IMatchService
    {
        public async Task CreateMatchAsync(CreateMatchDto createMatchDto)
        {
            var existingMatch = await _context.Matches.Include(x => x.HomeTeam).
                                                Include(x => x.AwayTeam).
                                                Where(x => x.Week == createMatchDto.Week).
                                                FirstOrDefaultAsync(x => x.HomeTeamId == createMatchDto.HomeTeamId ||
                                                              x.AwayTeamId == createMatchDto.AwayTeamId ||
                                                              x.HomeTeamId == createMatchDto.AwayTeamId ||
                                                              x.AwayTeamId == createMatchDto.HomeTeamId);
            if (existingMatch != null)
            {
                // Çakışan takım HomeTeamId mi yoksa AwayTeamId mi?
                string conflictingTeamName = (existingMatch.HomeTeamId == createMatchDto.HomeTeamId || existingMatch.AwayTeamId == createMatchDto.HomeTeamId)
                    ? (existingMatch.HomeTeamId == createMatchDto.HomeTeamId ? existingMatch.HomeTeam.Name : existingMatch.AwayTeam.Name)
                    : (existingMatch.HomeTeamId == createMatchDto.AwayTeamId ? existingMatch.HomeTeam.Name : existingMatch.AwayTeam.Name);

                throw new BadRequestException($"{conflictingTeamName} takımının {createMatchDto.Week}. haftada zaten kayıtlı bir maçı var!");
            }

            if(createMatchDto.Status == "Finished" &&  (createMatchDto.HomeScore == null || createMatchDto.AwayScore == null))
            {
                throw new BadRequestException("Tamamlandı durumunda ev sahibi ve deplasman takımın skorları boş geçilemez");
            }
            
            var match = _mapper.Map<Match>(createMatchDto);
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(int id)
        {
            var value = await _context.Matches.FindAsync(id);
            if (value == null)
            {
                throw new NotFoundException($"{id} sine sahip bir maç bulunamadı");
            }
            _context.Matches.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMatchDto>> GetAllMatchAsync()
        {
            var matches = await _context.Matches.Include(x => x.HomeTeam)
                                                .Include(x => x.AwayTeam)
                                                .OrderBy(x => x.Week)
                                                .ThenBy(x => x.MatchDate)
                                                .ToListAsync();

            var values = _mapper.Map<List<ResultMatchDto>>(matches);
            return values;
        }

        public async Task<ResultMatchDto> GetMatchByIdAsync(int id)
        {
            var match = await _context.Matches.Include(x => x.HomeTeam)
                                              .Include(x => x.AwayTeam)
                                              .FirstOrDefaultAsync(x => x.MatchId == id);
            var value = _mapper.Map<ResultMatchDto>(match);
            if (value == null)
            {
                throw new NotFoundException($"{id} sine sahip bir maç bulunamadı");
            }
            return value;
        }

        public async Task UpdateMatchAsync(UpdateMatchDto updateMatchDto)
        {
            var existingMatch = await _context.Matches.Include(x => x.HomeTeam).
                                                Include(x => x.AwayTeam).
                                                Where(x => x.Week == updateMatchDto.Week && x.MatchId != updateMatchDto.MatchId).
                                                FirstOrDefaultAsync(x => x.HomeTeamId == updateMatchDto.HomeTeamId ||
                                                              x.AwayTeamId == updateMatchDto.AwayTeamId ||
                                                              x.HomeTeamId == updateMatchDto.AwayTeamId ||
                                                              x.AwayTeamId == updateMatchDto.HomeTeamId);
            if (existingMatch != null)
            {
                // Çakışan takım HomeTeamId mi yoksa AwayTeamId mi?
                string conflictingTeamName = (existingMatch.HomeTeamId == updateMatchDto.HomeTeamId || existingMatch.AwayTeamId == updateMatchDto.HomeTeamId)
                    ? (existingMatch.HomeTeamId == updateMatchDto.HomeTeamId ? existingMatch.HomeTeam.Name : existingMatch.AwayTeam.Name)
                    : (existingMatch.HomeTeamId == updateMatchDto.AwayTeamId ? existingMatch.HomeTeam.Name : existingMatch.AwayTeam.Name);

                throw new BadRequestException($"{conflictingTeamName} takımının {updateMatchDto.Week}. haftada zaten kayıtlı bir maçı var!");
            }

            if (updateMatchDto.Status == "Finished" && (updateMatchDto.HomeScore == null || updateMatchDto.AwayScore == null))
            {
                throw new BadRequestException("Tamamlandı durumunda ev sahibi ve deplasman takımın skorları boş geçilemez");
            }


            var match = _mapper.Map<Match>(updateMatchDto);
            var value = _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }
    }
}
