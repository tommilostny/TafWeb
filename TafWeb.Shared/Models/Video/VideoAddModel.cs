namespace TafWeb.Shared.Models.Video;

public record VideoAddModel
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string VideoUrl { get; init; } = string.Empty;
    public string ThumbnailBase64 { get; init; } = string.Empty;
    public DateTime Published { get; init; }
    public string Route { get; init; } = string.Empty;
    public VideoCategoryType Category { get; init; }
}
