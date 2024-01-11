using ProfileMicroService.API.Arguments;
using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Interfaces.Mappers;

public interface IFollowMapper
{
    Follow SaveToDomain(FollowSave followSave);
    GetAllFollowersArgument GetAllFollowersRequestToDomain(GetAllFollowersRequest getAllFollowersRequest);
    PageList<FollowResponse> DomainPageListToResponsePageList(PageList<Follow> followPageList);
}
