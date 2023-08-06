namespace TafWeb.Shared.Models.TafUser;

public record TafUserListModel
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string ImageBase64 { get; init; } = string.Empty;
    public string TwitterUrl { get; init; } = string.Empty;
    public string MastodonUrl { get; init; } = string.Empty;
    public string FacebookUrl { get; init; } = string.Empty;
    public string InstagramUrl { get; init; } = string.Empty;
    public string LinkedInUrl { get; init; } = string.Empty;
    public string GitHubUrl { get; init; } = string.Empty;
}
