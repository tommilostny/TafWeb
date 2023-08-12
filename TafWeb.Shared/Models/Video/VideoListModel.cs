namespace TafWeb.Shared.Models.Video;

public record VideoListModel
{
    public string Title { get; init; } = string.Empty;
    public string ThumbnailBase64 { get; set; } = string.Empty;
    public string Route { get; init; } = string.Empty;
}
