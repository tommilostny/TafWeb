namespace TafWeb.DAL.Entities;

public record AboutUs
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string ShowReelVideoUrl { get; init; } = string.Empty;
    public string PeopleImageBase64 { get; init; } = string.Empty;
    public string[] ShortDesctiptionParagraphs { get; init; } = Array.Empty<string>();
    public string[] LongDescriptionParagraphs { get; init; } = Array.Empty<string>();
    public List<string> GalleryImageBase64s { get; init; } = new();
}
