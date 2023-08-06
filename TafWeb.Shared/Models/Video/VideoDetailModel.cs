namespace TafWeb.Shared.Models.Video;

public record VideoDetailModel
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string VideoUrl { get; init; } = string.Empty;
    public DateTime Published { get; init; }
}
