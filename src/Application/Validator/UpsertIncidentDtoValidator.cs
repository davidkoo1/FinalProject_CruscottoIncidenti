using Application.DTO;
using FluentValidation;

namespace Application.Validator
{
    public class UpsertIncidentDtoValidator : AbstractValidator<UpsertIncidentDto>
    {
        public UpsertIncidentDtoValidator()
        {
            RuleFor(x => x.RequestNr)
                .NotEmpty()
                .Length(17)
                .Must(a => a != null && a.StartsWith("HOST") == true).WithMessage("Start with HOST");

            RuleFor(x => x.Subsystem)
                .NotEmpty()
                .Length(2);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(35);

            RuleFor(x => x.ApplicationType)
                .NotEmpty()
                .MaximumLength(35);

            RuleFor(x => x.Urgency)
                .MaximumLength(35)
                .NotEmpty();

            RuleFor(x => x.SubCause)
                .NotEmpty()
                .MaximumLength(35);

            RuleFor(x => x.ProblemSummary)
                .MaximumLength(255);

            RuleFor(x => x.ProblemDescription)
                .MaximumLength(500);

            RuleFor(x => x.Solution)
                .MaximumLength(250);

            RuleFor(x => x.ThirdParty)
                .MaximumLength(35);

            RuleFor(x => x.OriginId)
                .NotEmpty();

            RuleFor(x => x.AmbitId)
                .NotEmpty();

            RuleFor(x => x.IncidentTypeId)
                .NotEmpty();

            RuleFor(x => x.ScenaryId)
                .NotEmpty();

            RuleFor(x => x.ThreatId)
                .NotEmpty();
        }
    }
}
