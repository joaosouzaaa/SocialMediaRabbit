using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Mappers;
using ProfileMicroService.API.Settings.PaginationSettings;
using ProfileMicroServiceUnitTests.TestBuilders;

namespace ProfileMicroServiceUnitTests.MappersTests;
public sealed class ProfileMapperTests
{
    private readonly ProfileMapper _profileMapper;

    public ProfileMapperTests()
    {
        _profileMapper = new ProfileMapper();
    }

    [Fact]
    public void SaveToDomain_SuccessfulScenario()
    {
        // A
        var profileSave = ProfileBuilder.NewObject().SaveBuild();

        // A
        var profileResult = _profileMapper.SaveToDomain(profileSave);

        // A
        Assert.Equal(profileResult.Username, profileSave.Username);
        Assert.Equal(profileResult.Email, profileSave.Email);
    }

    [Fact]
    public void DomainPageListToResponsePageList_SuccessfulScenario()
    {
        // A
        var profileList = new List<Profile>()
        {
            ProfileBuilder.NewObject().DomainBuild(),
            ProfileBuilder.NewObject().DomainBuild(),
        };
        var profilePageList = new PageList<Profile>()
        {
            CurrentPage = 1,
            PageSize = 123,
            Result = profileList,
            TotalCount = 123,
            TotalPages = 9
        };

        // A
        var profileResponsePageListResult = _profileMapper.DomainPageListToResponsePageList(profilePageList);

        // A
        Assert.Equal(profileResponsePageListResult.CurrentPage, profilePageList.CurrentPage);
        Assert.Equal(profileResponsePageListResult.PageSize, profilePageList.PageSize);
        Assert.Equal(profileResponsePageListResult.Result.Count, profilePageList.Result.Count);
        Assert.Equal(profileResponsePageListResult.TotalCount, profilePageList.TotalCount);
        Assert.Equal(profileResponsePageListResult.TotalPages, profilePageList.TotalPages);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var profile = ProfileBuilder.NewObject().DomainBuild();

        // A
        var profileResponseResult = _profileMapper.DomainToResponse(profile);

        // A
        Assert.Equal(profileResponseResult.Id, profile.Id);
        Assert.Equal(profileResponseResult.Username, profile.Username);
        Assert.Equal(profileResponseResult.Email, profile.Email);
        Assert.Equal(profileResponseResult.CreationDate, profile.CreationDate);
    }
}
