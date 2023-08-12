namespace TafWeb.Shared.Models.VideoCategory;

public record VideoCategoryEditModel
{
    public VideoCategoryType Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public bool IsVisible { get; set; } = false;
    public string MainPageText { get; set; } = string.Empty;
    public string DetailPageText { get; set; } = string.Empty;
}
