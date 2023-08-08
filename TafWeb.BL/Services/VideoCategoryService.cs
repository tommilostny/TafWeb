namespace TafWeb.BL.Services;

public class VideoCategoryService : IVideoCategoryService
{
    private readonly TafWebDbContext _dbContext;
    private readonly IMapper _mapper;

    public VideoCategoryService(TafWebDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<VideoCategoryListModel>> GetVideoCategoriesAsync()
    {
        return await _mapper.ProjectTo<VideoCategoryListModel>(_dbContext.VideoCategories.Where(vc => vc.IsVisible)).ToListAsync();
    }

    public async Task<VideoCategoryDetailModel> GetVideoCategoryDetailModelAsync(string categoryRoute)
    {
        return _mapper.Map<VideoCategoryDetailModel>(await _dbContext.VideoCategories.FirstAsync(vc => vc.Route == categoryRoute));
    }

    public async Task<VideoCategoryEditModel> GetVideoCategoryEditModelAsync(string categoryRoute)
    {
        return _mapper.Map<VideoCategoryEditModel>(await _dbContext.VideoCategories.FirstAsync(vc => vc.Route == categoryRoute));
    }

    public async Task UpdateVideoCategoryAsync(VideoCategoryEditModel model)
    {
        var categoryToUpdate = _dbContext.Attach(_mapper.Map<VideoCategory>(model));
        categoryToUpdate.State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
