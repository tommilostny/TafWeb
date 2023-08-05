namespace TafWeb.DAL.Entities;

public record AboutUs
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? ShowReelVideoUrl { get; set; }
    public string? PeopleImageUrl { get; set; }
    public string? ShortDesctiption { get; set; }

    public string? LongDescription { get; set; }
    public List<string> GalleryImageUrls { get; set; } = new();
}
