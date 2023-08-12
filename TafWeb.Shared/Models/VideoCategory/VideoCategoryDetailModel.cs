using TafWeb.Shared.Models.Video;

namespace TafWeb.Shared.Models.VideoCategory;

public record VideoCategoryDetailModel
{
    public string Name { get; init; } = string.Empty;
    public bool IsVisible { get; init; } = false;
    public string ShortDescription { get; init; } = string.Empty;
    public string LongDescription { get; init; } = string.Empty;
    public string BackgroundImageBase64 { get; init; } = string.Empty;
    public List<VideoListModel> Videos { get; set; } = new();
}
