namespace TafWeb.DAL.Entities;

public record VideoCategory
{
    public VideoCategoryType Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Route { get; init; } = string.Empty;
    public bool IsVisible { get; init; } = false;
    public string[] MainPageParagraphs { get; init; } = Array.Empty<string>();
    public string[] DetaiPageParagraphs { get; init; } = Array.Empty<string>();
}
