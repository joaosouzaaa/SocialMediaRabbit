namespace FollowerMicroService.API.Entities;

public sealed class Follow
{
    public int Id { get; set; }
    public required int FollowerId { get; set; }
    public required int ProfileId { get; set; }
}
