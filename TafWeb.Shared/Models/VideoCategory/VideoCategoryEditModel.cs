namespace TafWeb.Shared.Models.VideoCategory;

public record VideoCategoryEditModel
{
    public VideoCategoryType Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool IsVisible { get; init; } = false;
    public string ShortDescription { get; init; } = string.Empty;
    public string LongDescription { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
    public string BackgroundImageBase64 { get; init; } = string.Empty;
}
