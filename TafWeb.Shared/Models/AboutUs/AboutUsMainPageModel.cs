namespace TafWeb.Shared.Models.AboutUs;

public record AboutUsMainPageModel
{
    public string ShowReelVideoUrl { get; init; } = string.Empty;
    public string PeopleImageBase64 { get; init; } = string.Empty;
    public string[] ShortDesctiptionParagraphs { get; init; } = Array.Empty<string>();
}
