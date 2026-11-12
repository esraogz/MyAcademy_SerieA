using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.Exceptions;

namespace SerieA.WebApi.Services.Events
{
    public class EventService(AppDbContext _context,
                              IMapper _mapper) : IEventService
    {

        public async Task CreateEventAsync(CreateMatchEventDto createMatchEventDto)
        {
            if (createMatchEventDto.EventType == "Goal")
            {
                var goal = _mapper.Map<MatchGoal>(createMatchEventDto);
                goal.PlayerName = createMatchEventDto.ScorerPlayerName;

                await PlayerErrorsAsync(createMatchEventDto.MatchId, goal.PlayerName, createMatchEventDto.Minute, "Gol atamaz");

                await _context.MatchGoals.AddAsync(goal);
                var match = await _context.Matches.FindAsync(createMatchEventDto.MatchId);
                if (createMatchEventDto.TeamId == match.HomeTeamId)
                {
                    match.HomeScore = (match.HomeScore ?? 0) + 1;
                }

                else if (createMatchEventDto.TeamId == match.AwayTeamId)
                {
                    match.AwayScore = (match.AwayScore ?? 0) + 1;
                }
            }

            else if (createMatchEventDto.EventType == "Card")
            {
                var card = _mapper.Map<MatchCard>(createMatchEventDto);

                var cartType = createMatchEventDto.CardType ?? "Yellow";
                card.CartType = cartType;
                card.PlayerName = createMatchEventDto.CardPlayerName;

                await _context.MatchCards.AddAsync(card);
            }

            else if (createMatchEventDto.EventType == "Substitution")
            {
                await PlayerErrorsAsync(createMatchEventDto.MatchId, createMatchEventDto.PlayerInName, createMatchEventDto.Minute, "Oyuna giremez");
                await PlayerErrorsAsync(createMatchEventDto.MatchId, createMatchEventDto.PlayerOutName, createMatchEventDto.Minute, "Oyundan çıkamaz");

                var substitution = _mapper.Map<MatchSubstitution>(createMatchEventDto);
                await _context.MatchSubstitutions.AddAsync(substitution);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id, string type)
        {
            if (type == "Goal" || type == "Gol")
            {
                var goal = await _context.MatchGoals.FindAsync(id);
                if (goal != null)
                {
                    var match = await _context.Matches.FindAsync(goal.MatchId);  //Gole ait maçı buluyoruz
                    if (match != null)
                    {
                        if (goal.TeamId == match.HomeTeamId && match.HomeScore > 0)
                        {
                            match.HomeScore--;
                        }
                        else if (goal.TeamId == match.AwayTeamId && match.AwayScore > 0)
                        {
                            match.AwayScore--;
                        }
                    }
                    _context.MatchGoals.Remove(goal);
                }
            }

            else if (type == "Card" || type == "Sarı Kart" || type == "Kırmızı Kart")
            {
                var card = await _context.MatchCards.FindAsync(id);
                if (card != null)
                {
                    _context.MatchCards.Remove(card);
                }
            }

            else if (type == "Substitution" || type == "Değişiklik")
            {
                var substitution = await _context.MatchSubstitutions.FindAsync(id);
                _context.MatchSubstitutions.Remove(substitution);
            }

            await _context.SaveChangesAsync();


        }
        private async Task PlayerErrorsAsync(int matchId, string? playerName, int minute, string action)
        {
            if (string.IsNullOrWhiteSpace(playerName)) return;

            var name = playerName.Trim().ToLower();
            var cards = await _context.MatchCards
                .Where(c =>
                    c.MatchId == matchId &&
                    c.PlayerName.ToLower() == name &&
                    c.Minute <= minute)
                .OrderBy(c => c.Minute)
                .ThenBy(c => c.ExtraMinute)
                .ToListAsync();

            // Doğrudan kırmızı kart
            var red = cards.FirstOrDefault(c => c.CartType == "Red");
            if (red != null)
                throw new BadRequestException(
                    $"{playerName} {red.Minute}. dakikada kırmızı kart gördüğü için {minute}. dakikada {action}.");

            // İkinci sarı karttan kırmızı: ikinci sarının dakikası oyundan çıkış dakikasıdır
            var secondYellow = cards.Where(c => c.CartType == "Yellow").Skip(1).FirstOrDefault();
            if (secondYellow != null)
                throw new BadRequestException(
                    $"{playerName} {secondYellow.Minute}. dakikada ikinci sarı karttan kırmızı kart gördüğü için {minute}. dakikada {action}.");
        }
    }

}
