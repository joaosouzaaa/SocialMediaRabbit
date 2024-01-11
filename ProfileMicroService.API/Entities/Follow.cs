namespace ProfileMicroService.API.Entities;

public sealed class Follow
{
    public int Id { get; set; }
    public required int FollowerId { get; set; }
    public Profile Follower { get; set; }
    public required int FollowingId { get; set; }
    public Profile Following { get; set; }
}
