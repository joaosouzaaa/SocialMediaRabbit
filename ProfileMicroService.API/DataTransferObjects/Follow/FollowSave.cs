namespace ProfileMicroService.API.DataTransferObjects.Follow;

public sealed record FollowSave(int FollowerId,
                                int FollowingId)
{
}
