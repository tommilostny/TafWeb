namespace TafWeb.BL.Services.Interfaces;

public interface IClientFeedbackService
{
    Task<IReadOnlyCollection<ClientFeedbackListModel>> GetClientFeedbacksAsync();
    Task AddClientFeedbackAsync(ClientFeedbackAddModel model);
}
