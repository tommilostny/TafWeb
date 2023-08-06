﻿namespace TafWeb.Shared.Models.ClientFeedback;

public record ClientFeedbackListModel
{
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string ImageBase64 { get; set; } = string.Empty;
}
