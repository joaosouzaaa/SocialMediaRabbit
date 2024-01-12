namespace Contracts;
public sealed record FollowCreatedEvent(int FollowerId,
                                        int FollowingId)
{
}
