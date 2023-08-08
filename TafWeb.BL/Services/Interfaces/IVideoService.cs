namespace TafWeb.BL.Services.Interfaces;

public interface IVideoService
{
    Task<IReadOnlyCollection<VideoListModel>> GetAllVideosAsync();
    Task<IReadOnlyCollection<VideoListModel>> GetVideosFromCategoryAsync(string categoryRoute);
    Task<IReadOnlyCollection<VideoListModel>> GetVideosFromCategoryAsync(int count, string categoryRoute);
    Task<VideoDetailModel> GetVideoDetailModelAsync(string videoRoute);
    Task<VideoEditModel> GetVideoEditModelAsync(string videoRoute);
    Task UpdateVideoAsync(VideoEditModel model);
    Task AddVideoAsync (VideoAddModel model);
}
