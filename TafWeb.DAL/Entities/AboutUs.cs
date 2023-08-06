namespace TafWeb.DAL.Entities;

public record AboutUs
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string ShowReelVideoUrl { get; init; } = string.Empty;
    public string PeopleImageBase64 { get; init; } = string.Empty;
    public string ShortDesctiption { get; init; } = string.Empty;
    public string LongDescription { get; init; } = string.Empty; 
    public List<string> GalleryImageBase64s { get; init; } = new();
}
