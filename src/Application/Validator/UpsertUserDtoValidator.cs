using Application.DTO;
using Application.Resources;
using FluentValidation;

namespace Application.Validator
{
    public class UpsertUserDtoValidator : AbstractValidator<UpsertUserDto>
    {
        public UpsertUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(7)
                .MinimumLength(5)
                .Must(a => a != null && a.StartsWith("Cr") == true).WithMessage($"{Localization.StartWith} Cr00000")
                .WithName(Localization.Username);

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(35)
                .WithName(Localization.FullName);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100)
                .WithName(Localization.Email);

            RuleFor(x => x.RolesId)
                .NotNull()
                .NotEmpty()
                .WithName(Localization.Roles);
        }
    }
}
