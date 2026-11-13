using FluentValidation;
using SerieA.WebApi.DTOs.TeamDtos;

namespace SerieA.WebApi.ValidationRules.TeamValidators
{
    public class UpdateTeamValidator : AbstractValidator<UpdateTeamDto>
    {
        public UpdateTeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Takım adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Takım adı 2 karakterden az olamaz");
            RuleFor(x => x.ShortName).NotEmpty().WithMessage("Takım Kodu adı boş geçilemez");
            RuleFor(x => x.ShortName).MaximumLength(3).WithMessage("Takım Kodu 3 karakterden fazla olamaz");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş geçilemez");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Bölge seçimi boş geçilemez");
            RuleFor(x => x.Capacity).InclusiveBetween(1000, 100000).WithMessage("Kapasite 1000 kişiden az 100000 kişiden fazla olamaz");
            RuleFor(x => x.Founded).InclusiveBetween(1890, 2026).WithMessage("Kuruluş yılı 1890 dan eski olamaz");
            RuleFor(x => x.ColorA).NotEmpty().WithMessage("Ana renk boş geçilemez adı boş geçilemez");
            RuleFor(x => x.ColorB).NotEmpty().WithMessage("İkinci renk boş geçilemez adı boş geçilemez");
            RuleFor(x => x.Stadium).NotEmpty().WithMessage("Stadyum adı boş geçilemez");
        }
    }
}
