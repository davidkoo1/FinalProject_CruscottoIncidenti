using Application.DTO;
using Application.Resources;
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
                .Must(a => a != null && a.StartsWith("HOST") == true).WithMessage($"{Localization.StartWith} HOST")
                .WithName(Localization.RequestNr);

            RuleFor(x => x.CloseDate)
                .GreaterThanOrEqualTo(x => x.OpenDate).When(x => x.CloseDate.HasValue)
                .WithName(Localization.CloseDate);

            RuleFor(x => x.Subsystem)
                .NotEmpty()
                .Length(2)
                .WithName(Localization.Subsystem);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(35)
                .WithName(Localization.Type);

            RuleFor(x => x.ApplicationType)
                .NotEmpty()
                .MaximumLength(35)
                .WithName(Localization.ApplicationType);

            RuleFor(x => x.Urgency)
                .MaximumLength(35)
                .NotEmpty()
                .WithName(Localization.Urgency);

            RuleFor(x => x.SubCause)
                .NotEmpty()
                .MaximumLength(35)
                .WithName(Localization.SubCause);

            RuleFor(x => x.ProblemSummary)
                .MaximumLength(255)
                .WithName(Localization.ProblemSummary);

            RuleFor(x => x.ProblemDescription)
                .MaximumLength(500)
                .WithName(Localization.ProblemDescription);

            RuleFor(x => x.Solution)
                .MaximumLength(250)
                .WithName(Localization.Solution);

            RuleFor(x => x.ThirdParty)
                .MaximumLength(35)
                .WithName(Localization.ThirdParty);

            RuleFor(x => x.OriginId)
                .NotEmpty()
                .WithName(Localization.Origin);

            RuleFor(x => x.AmbitId)
                .NotEmpty()
                .WithName(Localization.Ambit);

            RuleFor(x => x.IncidentTypeId)
                .NotEmpty()
                .WithName(Localization.IncidentType);

            RuleFor(x => x.ScenaryId)
                .NotEmpty()
                .WithName(Localization.Scenary);

            RuleFor(x => x.ThreatId)
                .NotEmpty()
                .WithName(Localization.Threat);
        }
    }
}
