namespace TafWeb.BL.Services.Interfaces;

public interface IVideoCategoryService
{
    Task<IReadOnlyCollection<VideoCategoryListModel>> GetVideoCategoriesAsync();
    Task<VideoCategoryDetailModel> GetVideoCategoryDetailModelAsync(string categoryRoute);
    Task<VideoCategoryEditModel> GetVideoCategoryEditModelAsync(string categoryRoute);
    Task UpdateVideoCategoryAsync(VideoCategoryEditModel model);
}
