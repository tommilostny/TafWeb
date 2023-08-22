using System.Windows.Markup;

namespace TafWeb.Shared.Models.OrderFormEntry;

public record OrderFormEntryAddModel
{
    [Required(ErrorMessage = "Musíte zadat vaše jméno.")]
    [MaxLength(50, ErrorMessage = "Jméno nesmí být delší než 50 znaků.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Musíte zadat váš e-mail.")]
    [EmailAddress(ErrorMessage = "Musíte zadat platný e-mail.")]
    [MaxLength(50, ErrorMessage = "E-mail nesmí být delší než 50 znaků.")]
    public string Email { get; set; } = string.Empty;

    [MaxLength(2000, ErrorMessage = "Vaše zpráva nesmí být delší než 2000 znaků.")]
    public string Message { get; set; } = string.Empty;

    public VideoCategoryType VideoCategory { get; set; }

    [DateValidator]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string Place { get; set; } = string.Empty;

    private class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return !(value is DateOnly date && date < DateOnly.FromDateTime(DateTime.Now));
        }

        public override string FormatErrorMessage(string _)
        {
            return "Datum nesmí být v minulosti.";
        }
    }
}
