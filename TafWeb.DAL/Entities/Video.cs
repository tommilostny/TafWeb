namespace TafWeb.DAL.Entities;

public record Video
{
    public string PageUrl { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string? VideoUrl { get; init; }
    public string? Thumbnail { get; init; }
    public DateTime Published { get; init; }
}
