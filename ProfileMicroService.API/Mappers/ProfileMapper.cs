using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Mappers;

public sealed class ProfileMapper : IProfileMapper
{
    public Profile SaveToDomain(ProfileSave profileSave) =>
        new()
        {
            CreationDate = DateTime.UtcNow,
            Email = profileSave.Email,
            Username = profileSave.Username
        };

    public PageList<ProfileResponse> DomainPageListToResponsePageList(PageList<Profile> profilePageList) =>
        new()
        {
            CurrentPage = profilePageList.CurrentPage,
            PageSize = profilePageList.PageSize,
            Result = profilePageList.Result.Select(DomainToResponse).ToList(),
            TotalCount = profilePageList.TotalCount,
            TotalPages = profilePageList.TotalPages
        };

    private ProfileResponse DomainToResponse(Profile profile) =>
        new(profile.Id,
            profile.Username,
            profile.Email,
            profile.CreationDate);
}
