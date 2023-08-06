namespace TafWeb.Shared.Models.OrderFormEntry;

public record OrderFormEntryListModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public VideoCategoryType VideoCategory { get; init; }
    public DateOnly Date { get; init; }
    public string Place { get; init; } = string.Empty;
}
