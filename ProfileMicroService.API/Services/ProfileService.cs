using FluentValidation;
using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Interfaces.NotificationSettings;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Settings.NotificationSettings;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Services;

public sealed class ProfileService : IProfileService, IProfileExistsServiceFacade
{
    private readonly IProfileRepository _profileRepository;
    private readonly IProfileMapper _profileMapper;
    private readonly IValidator<Profile> _profileValidator;
    private readonly INotificationHandler _notificationHandler;

    public ProfileService(IProfileRepository profileRepository, IProfileMapper profileMapper,
                          IValidator<Profile> profileValidator, INotificationHandler notificationHandler)
    {
        _profileRepository = profileRepository;
        _profileMapper = profileMapper;
        _profileValidator = profileValidator;
        _notificationHandler = notificationHandler;
    }

    public async Task<bool> AddAsync(ProfileSave profileSave)
    {
        var profile = _profileMapper.SaveToDomain(profileSave);

        if (!await IsValidAsync(profile))
            return false;

        return await _profileRepository.AddAsync(profile);
    }

    public async Task<PageList<ProfileResponse>> GetAllPaginatedAsync(PageParameters pageParameters)
    {
        var profilePageList = await _profileRepository.GetAllPaginatedAsync(pageParameters);

        return _profileMapper.DomainPageListToResponsePageList(profilePageList);
    }

    public Task<bool> ExistsAsync(int id) =>
        _profileRepository.ExistsAsync(id);

    private async Task<bool> IsValidAsync(Profile profile)
    {
        var validationResult = await _profileValidator.ValidateAsync(profile);

        if (validationResult.IsValid)
            return true;

        foreach(var error in validationResult.Errors)
        {
            var notification = new Notification()
            {
                Key = error.PropertyName,
                Message = error.ErrorMessage
            };

            _notificationHandler.AddNotification(notification);
        }

        return false;
    }
}
