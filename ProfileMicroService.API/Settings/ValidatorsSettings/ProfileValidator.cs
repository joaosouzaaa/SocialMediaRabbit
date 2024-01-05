using FluentValidation;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Enums;
using ProfileMicroService.API.Extensions;

namespace ProfileMicroService.API.Settings.ValidatorsSettings;

public sealed class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(p => p.Username).Length(2, 50)
            .WithMessage(p => string.IsNullOrEmpty(p.Username)
            ? EMessage.Required.Description().FormatTo("Username")
            : EMessage.InvalidLength.Description().FormatTo("Username", "2 to 50"));

        RuleFor(p => p.Email).EmailAddress()
            .WithMessage(EMessage.InvalidFormat.Description().FormatTo("Email"));
    }
}
