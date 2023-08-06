namespace TafWeb.BL.Services.Interfaces;

public interface IVideoService
{
    Task<List<VideoListModel>> GetAllVideosAsync();
    Task<List<VideoListModel>> GetVideosFromCategoryAsync(string categoryRoute);
    Task<List<VideoListModel>> GetVideosFromCategoryAsync(int count, string categoryRoute);
    Task<VideoDetailModel> GetVideoDetailModelAsync(string videoRoute);
    Task<VideoEditModel> GetVideoEditModelAsync(string videoRoute);
    Task UpdateVideoAsync(VideoEditModel model);
    Task AddVideoAsync (VideoAddModel model);
}
