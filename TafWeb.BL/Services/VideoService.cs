namespace TafWeb.BL.Services;

public class VideoService : IVideoService
{
    private readonly TafWebDbContext _dbContext;
    private readonly IMapper _mapper;

    public VideoService(TafWebDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddVideoAsync(VideoAddModel model)
    {
        var existingVideo = await _dbContext.Videos.FirstOrDefaultAsync(v => v.Route == model.Route);
        if (existingVideo is not null)
        {
            throw new InvalidOperationException($"Video with route '{model.Route}' already exists.");
        }
        var entity = _mapper.Map<Video>(model);
        _dbContext.Videos.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<VideoDetailModel> GetVideoDetailModelAsync(string videoRoute)
    {
        var video = await _dbContext.Videos.FirstAsync(v => v.Route == videoRoute);
        return _mapper.Map<VideoDetailModel>(video);
    }

    public async Task<VideoEditModel> GetVideoEditModelAsync(string videoRoute)
    {
        var video = await _dbContext.Videos.FirstAsync(v => v.Route == videoRoute);
        return _mapper.Map<VideoEditModel>(video);
    }

    public async Task<IReadOnlyCollection<VideoListModel>> GetAllVideosAsync()
    {
        return await _mapper.ProjectTo<VideoListModel>(_dbContext.Videos).ToListAsync();
    }

    public async Task<IReadOnlyCollection<VideoListModel>> GetVideosFromCategoryAsync(string categoryRoute)
    {
        var categoryId = (await _dbContext.VideoCategories.FirstAsync(c => c.Route == categoryRoute)).Id;

        var videos = _dbContext.Videos
            .Where(v => v.Category == categoryId)
            .OrderByDescending(v => v.Published);

        return await _mapper.ProjectTo<VideoListModel>(videos).ToListAsync();
    }

    public async Task<IReadOnlyCollection<VideoListModel>> GetVideosFromCategoryAsync(int count, string categoryRoute)
    {
        var categoryId = (await _dbContext.VideoCategories.FirstAsync(c => c.Route == categoryRoute)).Id;

        var videos = _dbContext.Videos
            .Where(v => v.Category == categoryId)
            .OrderByDescending(v => v.Published)
            .Take(count);
        
        return await _mapper.ProjectTo<VideoListModel>(videos).ToListAsync();
    }

    public async Task UpdateVideoAsync(VideoEditModel model)
    {
        var videoToUpdate = _dbContext.Attach(_mapper.Map<Video>(model));
        videoToUpdate.State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<string> GetVideoBase64Thumbnail(string videoRoute)
    {
        var video = await _dbContext.Videos.FirstAsync(v => v.Route == videoRoute);
        return video.ThumbnailBase64;
    }
}
