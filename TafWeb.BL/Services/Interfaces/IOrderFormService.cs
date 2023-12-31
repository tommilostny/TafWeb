﻿namespace TafWeb.BL.Services.Interfaces;

public interface IOrderFormService
{
    Task<IReadOnlyCollection<OrderFormEntryListModel>> GetOrderFormEntriesAsync();
    Task<OrderFormEntryDetailModel> GetOrderFormEntryById(Guid id);
    Task AddOrderFormEntryAsync(OrderFormEntryAddModel model);
    Task<string> GetHeadlineAsync();
    Task<string> GetHeadlineAsync(string categoryRoute);
}
