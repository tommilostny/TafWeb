namespace TafWeb.BL.Services.Interfaces;

public interface IClientFeedbackService
{
    Task<List<ClientFeedbackListModel>> GetClientFeedbacksAsync();
    Task AddClientFeedbackAsync(ClientFeedbackAddModel model);
}
