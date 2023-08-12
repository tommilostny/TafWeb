namespace TafWeb.Shared.Models.FAQ;

public record FAQListModel
{
    public string Question { get; init; } = string.Empty;
    public string Answer { get; init; } = string.Empty;
}
