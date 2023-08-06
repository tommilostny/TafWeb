namespace TafWeb.Shared.Models.TafUser;

public class TafUserEditModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string ImageBase64 { get; init; } = string.Empty;
    public string TwitterUrl { get; init; } = string.Empty;
    public string MastodonUrl { get; init; } = string.Empty;
    public string FacebookUrl { get; init; } = string.Empty;
    public string InstagramUrl { get; init; } = string.Empty;
    public string LinkedInUrl { get; init; } = string.Empty;
    public string GitHubUrl { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
