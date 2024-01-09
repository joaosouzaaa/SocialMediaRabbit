using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;

namespace FollowerMicroService.API.Interfaces.Mappers;

public interface IFollowMapper
{
    Follow SaveToDomain(FollowSave followSave);
}
