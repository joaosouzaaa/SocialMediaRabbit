using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Arguments;

public sealed class GetAllFollowersArgument : PageParameters
{
    public required int FollowingId { get; set; }
}
