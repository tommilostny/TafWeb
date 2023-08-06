namespace TafWeb.Shared.Models.OrderFormEntry;

public record OrderFormEntryDetailModel
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public VideoCategoryType VideoCategory { get; init; }
    public DateOnly Date { get; init; }
    public string Place { get; init; } = string.Empty;
}
