using FluentValidation;

namespace Net8AuthExample.Api;

public class RequestValidator : AbstractValidator<Request>
{
    public RequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.PersonalId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}