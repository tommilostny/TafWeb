namespace TafWeb.BL.Services;

public class AboutUsService : IAboutUsService
{
    private readonly TafWebDbContext _dbContext;
    private readonly UserManager<TafUser> _userManager;
    private readonly IMapper _mapper;

    public AboutUsService(TafWebDbContext dbContext, UserManager<TafUser> userManager, IMapper mapper)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<AboutUsMainPageModel> GetMainPageModelAsync()
    {
        var entity = await _dbContext.AboutUs.FirstOrDefaultAsync();
        return _mapper.Map<AboutUsMainPageModel>(entity);
    }

    public async Task<AboutUsDetailModel> GetDetailModelAsync()
    {
        var entity = await _dbContext.AboutUs.FirstOrDefaultAsync();
        var model = _mapper.Map<AboutUsDetailModel>(entity);
        model.Users = await _mapper.ProjectTo<TafUserListModel>(_userManager.Users)
            .OrderBy(u => u.Name)
            .ToListAsync();
        return model;
    }

    public async Task UpdateAboutUsAsync(AboutUsEditModel model)
    {
        var aboutUsToUpdate = _dbContext.Attach(_mapper.Map<AboutUs>(model));
        aboutUsToUpdate.State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
