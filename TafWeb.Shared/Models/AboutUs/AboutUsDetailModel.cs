using TafWeb.Shared.Models.TafUser;

namespace TafWeb.Shared.Models.AboutUs;

public record AboutUsDetailModel
{
    public string[] LongDescriptionParagraphs { get; init; } = Array.Empty<string>();
    public List<string> GalleryImageBase64s { get; init; } = new();
    public List<TafUserListModel>? Users { get; set; } = null;
}
