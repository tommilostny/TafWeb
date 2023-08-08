namespace TafWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientFeedbackController : ControllerBase
{
    private readonly ILogger<ClientFeedbackController> _logger;
    private readonly IClientFeedbackService _clientFeedbackService;

    public ClientFeedbackController(ILogger<ClientFeedbackController> logger, IClientFeedbackService clientFeedbackService)
    {
        _logger = logger;
        _clientFeedbackService = clientFeedbackService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ClientFeedbackListModel>>> GetAsync()
    {
        try
        {
            var clientFeedbacks = await _clientFeedbackService.GetClientFeedbacksAsync();
            return Ok(clientFeedbacks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client feedbacks");
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] ClientFeedbackAddModel clientFeedbackAddModel)
    {
        try
        {
            await _clientFeedbackService.AddClientFeedbackAsync(clientFeedbackAddModel);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding client feedback");
            return BadRequest(ex);
        }
    }
}
