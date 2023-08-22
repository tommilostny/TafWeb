namespace TafWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderFormController : ControllerBase
{
    private readonly ILogger<OrderFormController> _logger;
    private readonly IOrderFormService _orderFormService;

    public OrderFormController(ILogger<OrderFormController> logger, IOrderFormService orderFormService)
    {
        _logger = logger;
        _orderFormService = orderFormService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<OrderFormEntryListModel>>> GetAllAsync()
    {
        try
        {
            var formEntries = await _orderFormService.GetOrderFormEntriesAsync();
            return Ok(formEntries);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client feedbacks");
            return BadRequest(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderFormEntryDetailModel>> GetAsync(Guid id)
    {
        try
        {
            var formEntry = await _orderFormService.GetOrderFormEntryById(id);
            return Ok(formEntry);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client feedback");
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] OrderFormEntryAddModel orderFormEntryAddModel)
    {
        try
        {
            await _orderFormService.AddOrderFormEntryAsync(orderFormEntryAddModel);
            //TODO: Send notification to Telegram.
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding client feedback");
            return BadRequest(ex);
        }
    }

    [HttpGet("headline")]
    public async Task<ActionResult<string>> GetHeadlineAsync()
    {
        try
        {
            var headlineText = await _orderFormService.GetHeadlineAsync();
            return Ok(headlineText);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting headline");
            return BadRequest(ex);
        }
    }

    [HttpGet("headline/{categoryRoute}")]
    public async Task<ActionResult<string>> GetHeadlineAsync(string categoryRoute)
    {
        try
        {
            var headlineText = await _orderFormService.GetHeadlineAsync(categoryRoute);
            return Ok(headlineText);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting headline");
            return BadRequest(ex);
        }
    }
}
