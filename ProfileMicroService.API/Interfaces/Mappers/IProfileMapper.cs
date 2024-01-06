using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Interfaces.Mappers;

public interface IProfileMapper
{
    Profile SaveToDomain(ProfileSave profileSave);
    PageList<ProfileResponse> DomainPageListToResponsePageList(PageList<Profile> profilePageList);
}
