namespace ProfileMicroService.API.DataTransferObjects.Profile;

public sealed class ProfileResponse
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required DateTime CreationDate { get; set; }
}
