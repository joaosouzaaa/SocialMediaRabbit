using FluentValidation;
using ProfileService.API.Domain.Entities;

namespace ProfileService.API.Settings.ValidatorsSettings;

public sealed class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        //RuleFor(p => p.Username).Length(2, 50)
        //    .WithMessage(p => string.IsNullOrEmpty(p.Username)
        //    ? )
    }
}
