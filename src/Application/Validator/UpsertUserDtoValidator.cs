using Application.DTO;
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
              .Must(a => a != null && a.StartsWith("Cr") == true).WithMessage("Start Cr00000");

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(35);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(x => x.RolesId)
                .NotNull()
                .NotEmpty().WithMessage("Select one role");
        }
    }
}
