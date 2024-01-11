using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Settings.PaginationSettings;
using ProfileMicroService.API.Arguments;

namespace ProfileMicroService.API.Mappers;

public sealed class FollowMapper : IFollowMapper
{
    private readonly IProfileMapper _profileMapper;

    public FollowMapper(IProfileMapper profileMapper)
    {
        _profileMapper = profileMapper;
    }

    public Follow SaveToDomain(FollowSave followSave) =>
        new()
        {
            FollowerId = followSave.FollowerId,
            FollowingId = followSave.FollowingId
        };

    public GetAllFollowersArgument GetAllFollowersRequestToDomain(GetAllFollowersRequest getAllFollowersRequest) =>
        new()
        {
            FollowingId = getAllFollowersRequest.FollowingId,
            PageNumber = getAllFollowersRequest.PageNumber,
            PageSize = getAllFollowersRequest.PageSize
        };

    public PageList<FollowResponse> DomainPageListToResponsePageList(PageList<Follow> followPageList) =>
        new()
        {
            CurrentPage = followPageList.CurrentPage,
            PageSize = followPageList.PageSize,
            Result = followPageList.Result.Select(DomainToResponse).ToList(),
            TotalCount = followPageList.TotalCount,
            TotalPages = followPageList.TotalPages
        };

    private FollowResponse DomainToResponse(Follow follow) =>
        new()
        {
            Follower = _profileMapper.DomainToResponse(follow.Follower),
            Id = follow.Id
        };
}
