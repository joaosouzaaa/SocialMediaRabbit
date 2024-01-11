using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.DataTransferObjects.Follow;

public sealed class GetAllFollowersRequest : PageParameters
{
    public required int FollowingId { get; set; }
}
