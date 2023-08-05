namespace TafWeb.DAL.Entities;

public record VideoCategory
{
    public VideoCategoryType Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string? LongDescription { get; set; }
    public string? BackgroundImageUrl { get; set; }
    public List<Video> Videos { get; set; } = new();
}
