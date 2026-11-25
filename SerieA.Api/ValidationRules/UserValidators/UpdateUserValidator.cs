using FluentValidation;
using SerieA.WebApi.DTOs.UserDtos;

namespace SerieA.WebApi.ValidationRules.UserValidators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez")
                               .EmailAddress().WithMessage("Geçerli bir email adresi girin");
            RuleFor(x => x.Roles).NotEmpty().WithMessage("Rol adı boş geçilemez");
        }
    }
}
