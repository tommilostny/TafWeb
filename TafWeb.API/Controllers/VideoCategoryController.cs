namespace TafWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoCategoryController : ControllerBase
{
    private readonly ILogger<VideoCategoryController> _logger;
    private readonly IVideoCategoryService _videoCategoryService;

    public VideoCategoryController(ILogger<VideoCategoryController> logger, IVideoCategoryService videoCategoryService)
    {
        _logger = logger;
        _videoCategoryService = videoCategoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<VideoCategoryListModel>>> GetAllAsync()
    {
        try
        {
            var categories = await _videoCategoryService.GetVideoCategoriesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video categories");
            return BadRequest(ex);
        }
    }

    [HttpGet("{categoryRoute}")]
    public async Task<ActionResult<VideoCategoryDetailModel>> GetByRouteAsync(string categoryRoute)
    {
        try
        {
            var category = await _videoCategoryService.GetVideoCategoryDetailModelAsync(categoryRoute);
            return Ok(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video category");
            return BadRequest(ex);
        }
    }

    //TODO: Authorize
    [HttpGet("edit/{categoryRoute}")]
    public async Task<ActionResult<VideoCategoryEditModel>> GetEditModelByRouteAsync(string categoryRoute)
    {
        try
        {
            var category = await _videoCategoryService.GetVideoCategoryEditModelAsync(categoryRoute);
            return Ok(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video category edit model");
            return BadRequest(ex);
        }
    }

    //TODO: Authorize
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] VideoCategoryEditModel category)
    {
        try
        {
            await _videoCategoryService.UpdateVideoCategoryAsync(category);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating video category");
            return BadRequest(ex);
        }
    }
}
