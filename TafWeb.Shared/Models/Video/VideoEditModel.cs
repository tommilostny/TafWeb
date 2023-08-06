namespace TafWeb.Shared.Models.Video;

public record VideoEditModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string VideoUrl { get; init; } = string.Empty;
    public string ThumbnailBase64 { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
    public DateTime Published { get; init; }
    public VideoCategoryType Category { get; init; }
}
