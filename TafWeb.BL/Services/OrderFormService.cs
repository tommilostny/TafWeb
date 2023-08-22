namespace TafWeb.BL.Services;

public class OrderFormService : IOrderFormService
{
    private readonly TafWebDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrderFormService(TafWebDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddOrderFormEntryAsync(OrderFormEntryAddModel model)
    {
        await _dbContext.FormEntries.AddAsync(_mapper.Map<OrderFormEntry>(model));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<string> GetHeadlineAsync()
    {
        var entity = await _dbContext.FormHeadlines.FirstOrDefaultAsync(fh => fh.VideoCategory == -1);
        return entity?.Text ?? "Objednávkový formulářřř";
    }

    public async Task<string> GetHeadlineAsync(string categoryRoute)
    {
        var category = await _dbContext.VideoCategories.FirstOrDefaultAsync(vc => vc.Route == categoryRoute);
        if (category is null)
        {
            return "Objednávkový formulářřř";
        }
        var entity = await _dbContext.FormHeadlines.FirstOrDefaultAsync(fh => fh.VideoCategory == (int)category.Id);
        return entity?.Text ?? "Objednávkový formulářřř";
    }

    public async Task<IReadOnlyCollection<OrderFormEntryListModel>> GetOrderFormEntriesAsync()
    {
        return await _mapper.ProjectTo<OrderFormEntryListModel>(_dbContext.FormEntries).ToListAsync();
    }

    public async Task<OrderFormEntryDetailModel> GetOrderFormEntryById(Guid id)
    {
        return _mapper.Map<OrderFormEntryDetailModel>(await _dbContext.FormEntries.FirstAsync(x => x.Id == id));
    }
}
