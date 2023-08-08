namespace TafWeb.BL.Services;

public class ClientFeedbackService : IClientFeedbackService
{
    private readonly TafWebDbContext _dbContext;
    private readonly IMapper _mapper;

    public ClientFeedbackService(TafWebDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddClientFeedbackAsync(ClientFeedbackAddModel model)
    {
        await _dbContext.ClientFeedbacks.AddAsync(_mapper.Map<ClientFeedback>(model));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<ClientFeedbackListModel>> GetClientFeedbacksAsync()
    {
        return await _mapper.ProjectTo<ClientFeedbackListModel>(_dbContext.ClientFeedbacks).ToListAsync();
    }
}
