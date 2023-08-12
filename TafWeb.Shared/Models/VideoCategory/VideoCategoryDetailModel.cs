using TafWeb.Shared.Models.FAQ;
using TafWeb.Shared.Models.Video;

namespace TafWeb.Shared.Models.VideoCategory;

public record VideoCategoryDetailModel
{
    public string Name { get; init; } = string.Empty;
    public bool IsVisible { get; init; } = false;
    public string[] Paragraphs { get; init; } = Array.Empty<string>();
    public List<VideoListModel> Videos { get; set; } = new();
    public List<FAQListModel> Faqs { get; set; } = new();
}
