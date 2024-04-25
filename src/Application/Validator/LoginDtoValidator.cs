using Application.DTO;
using Application.Resources;
using FluentValidation;

namespace Application.Validator
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithName(Localization.Username);
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(4).WithName(Localization.Password);
        }
    }
}
