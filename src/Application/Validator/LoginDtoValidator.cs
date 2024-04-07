using Application.DTO;
using FluentValidation;

namespace Application.Validator
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithName("tEST"/*Localization.username*/);
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(4);//.WithName(Localization.password);
        }
    }
}
