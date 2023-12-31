﻿namespace TafWeb.BL.Services;

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
        var categoryEntity = await _dbContext.VideoCategories.FirstAsync(vc => vc.Route == categoryRoute);
        var categoryModel = _mapper.Map<VideoCategoryDetailModel>(categoryEntity);

        var videos = _dbContext.Videos
            .Where(v => v.Category == categoryEntity.Id)
            .OrderByDescending(v => v.Published);

        categoryModel.Videos = await _mapper.ProjectTo<VideoListModel>(videos).ToListAsync();
        categoryModel.Faqs = await _mapper.ProjectTo<FAQListModel>(_dbContext.Faqs.Where(f => f.Category == categoryEntity.Id)).ToListAsync();
        return categoryModel;
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
