using FluentValidation;
using SerieA.WebApi.DTOs.MatchDtos;

namespace SerieA.WebApi.ValidationRules.MatchValidators
{
    public class UpdateMatchValidator : AbstractValidator<UpdateMatchDto>
    {
       
        public UpdateMatchValidator()
        {
            RuleFor(x => x.MatchId)
                .GreaterThan(0).WithMessage("Geçersiz maç kimliği");

            RuleFor(x => x.Week)
                .InclusiveBetween(1, 38).WithMessage("Hafta 1 ile 38 arasında olmalıdır");

            RuleFor(x => x.MatchDate)
                .NotEmpty().WithMessage("Maç tarihi ve saati boş geçilemez");

            RuleFor(x => x.Stadium)
                .NotEmpty().WithMessage("Stadyum adı boş geçilemez");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Maç durumu boş geçilemez")
                .When(x => !string.IsNullOrEmpty(x.Status));

            RuleFor(x => x.HomeTeamId)
                .GreaterThan(0).WithMessage("Ev sahibi takım seçilmelidir");

            RuleFor(x => x.AwayTeamId)
                .GreaterThan(0).WithMessage("Deplasman takımı seçilmelidir")
                .NotEqual(x => x.HomeTeamId).WithMessage("Ev sahibi ve deplasman takımı aynı olamaz");

            RuleFor(x => x.HomeScore)
                .InclusiveBetween(0, 20).WithMessage("Skor 0 ile 20 arasında olmalıdır")
                .When(x => x.HomeScore.HasValue);

            RuleFor(x => x.AwayScore)
                .InclusiveBetween(0, 20).WithMessage("Skor 0 ile 20 arasında olmalıdır")
                .When(x => x.AwayScore.HasValue);

            RuleFor(x => x.Season)
                .NotEmpty().WithMessage("Sezon boş geçilemez");
        }
    }
}
