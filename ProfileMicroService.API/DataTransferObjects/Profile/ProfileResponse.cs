namespace ProfileMicroService.API.DataTransferObjects.Profile;

public sealed record ProfileResponse(int Id,
                                     string Username,
                                     string Email,
                                     DateTime CreationDate)
{
}
