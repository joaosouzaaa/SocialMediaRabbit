namespace FollowerMicroService.API.DataTransferObjects.Follow;

public sealed class FollowSave
{
    public required int FollowerId { get; set; }
    public required int FollowingId { get; set; }
}
