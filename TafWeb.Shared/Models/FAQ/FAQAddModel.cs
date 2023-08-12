namespace TafWeb.Shared.Models.FAQ;

public record FAQAddModel
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public VideoCategoryType Category { get; set; }
}
