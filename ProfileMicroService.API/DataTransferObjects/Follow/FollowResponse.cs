using ProfileMicroService.API.DataTransferObjects.Profile;

namespace ProfileMicroService.API.DataTransferObjects.Follow;

public sealed class FollowResponse
{
    public required int Id { get; set; }
    public required ProfileResponse Follower { get; set; }
}
