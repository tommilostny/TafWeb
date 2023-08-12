namespace TafWeb.Shared.Models.VideoCategory;

public class VideoCategoryListModel
{
    public string Name { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
    public string[] Paragraphs { get; init; } = Array.Empty<string>();
}
