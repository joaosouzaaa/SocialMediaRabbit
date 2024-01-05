namespace ProfileMicroService.API.Entities;

public sealed class Profile
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required DateTime CreationDate { get; set; }
}
