using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.TeamDtos;
using SerieA.WebApi.Exceptions;

namespace SerieA.WebApi.Services.Teams
{
    public class TeamService(AppDbContext _context,
                             IMapper _mapper) : ITeamService
    {
        public async Task CreateTeamAsync(CreateTeamDto createTeamDto)
        {
            bool isTeamExist = await _context.Teams.AnyAsync(x => x.Name.ToLower() == createTeamDto.Name.Trim().ToLower() ||
                                                                  x.ShortName.ToLower() == createTeamDto.ShortName.Trim().ToLower());
            if (isTeamExist)
            {
                throw new BadRequestException($" Eklemeye çalıştığınız {createTeamDto.Name} takımı veya {createTeamDto.ShortName} kodu listede zaten mevcut");
            }
            if (createTeamDto.IsActive) //Eklemek istediğimiz takım aktifse içeri girer pasifse direkt ekler.
            {
                var teamCount = await _context.Teams.CountAsync(x => x.IsActive);
                if (teamCount >= 20)
                {
                    throw new BadRequestException("Ligde maksimum 20 tane aktif takım olabilir. Ya takımlardan birini pasife çekin ya da işlemi iptal edin");
                }
            }

            var team = _mapper.Map<Team>(createTeamDto);
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new NotFoundException($"{id} sine sahip bir takım bulunamadı");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultTeamDto>> GetAllTeamAsync()
        {
            var teams = await _context.Teams.ToListAsync();
            var values = _mapper.Map<List<ResultTeamDto>>(teams);
            return values;
        }

        public async Task<ResultTeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new NotFoundException($"{id} sine sahip bir takım bulunamadı");
            }
            var value = _mapper.Map<ResultTeamDto>(team);
            return value;

        }

        public async Task UpdateTeamAsync(UpdateTeamDto updateTeamDto)
        {
            bool isTeamExist = await _context.Teams.AnyAsync(x => x.Name != updateTeamDto.Name &&
                                                           (x.Name.ToLower() == updateTeamDto.Name.Trim().ToLower() ||
                                                            x.ShortName.ToLower() == updateTeamDto.ShortName.Trim().ToLower()));
            if (isTeamExist)
            {
                throw new BadRequestException($" Eklemeye çalıştığınız {updateTeamDto.Name} takımı veya {updateTeamDto.ShortName} kodu listede zaten mevcut");
            }

            if (updateTeamDto.IsActive)
            {
                var teamCount = await _context.Teams.CountAsync(x => x.IsActive && x.TeamId != updateTeamDto.TeamId);
                if (teamCount >= 20)
                {
                    throw new BadRequestException("Ligde maksimum 20 tane aktif takım olabilir. Bu takımı aktif yapmak için önce başka bir takımı pasife çekin.");
                }
            }
            var team = _mapper.Map<Team>(updateTeamDto);
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }
    }
}
