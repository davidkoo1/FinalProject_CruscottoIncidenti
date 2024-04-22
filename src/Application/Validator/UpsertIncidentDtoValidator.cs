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
                .Length(17);

            RuleFor(x => x.Subsystem)
                .NotEmpty()
                .Length(2);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ApplicationType)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Urgency)
                .NotEmpty();

            RuleFor(x => x.SubCause)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ProblemSummary)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.ProblemDescription)
                .NotEmpty()
                .MaximumLength(350);

            RuleFor(x => x.Solution)
                .NotEmpty()
                .MaximumLength(350);

            RuleFor(x => x.ThirdParty)
                .MaximumLength(50);

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
