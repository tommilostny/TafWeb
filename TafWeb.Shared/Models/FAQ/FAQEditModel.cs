namespace TafWeb.Shared.Models.FAQ;

public record FAQEditModel
{
    public Guid Id { get; init; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}
