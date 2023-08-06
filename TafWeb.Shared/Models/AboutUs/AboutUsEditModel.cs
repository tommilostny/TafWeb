namespace TafWeb.Shared.Models.AboutUs;

public record AboutUsEditModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string ShowReelVideoUrl { get; set; } = string.Empty;
    public string PeopleImageBase64 { get; set; } = string.Empty;
    public string ShortDesctiption { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public List<string> GalleryImageBase64s { get; init; } = new();
}
