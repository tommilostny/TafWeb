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

    public async Task<List<OrderFormEntryListModel>> GetOrderFormEntriesAsync()
    {
        return await _mapper.ProjectTo<OrderFormEntryListModel>(_dbContext.FormEntries).ToListAsync();
    }

    public async Task<OrderFormEntryDetailModel> GetOrderFormEntryById(Guid id)
    {
        return _mapper.Map<OrderFormEntryDetailModel>(await _dbContext.FormEntries.FirstAsync(x => x.Id == id));
    }
}
