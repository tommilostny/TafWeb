namespace TafWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController : ControllerBase
{
    private readonly ILogger<VideoController> _logger;
    private readonly IVideoService _videoService;

    public VideoController(ILogger<VideoController> logger, IVideoService videoService)
    {
        _logger = logger;
        _videoService = videoService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<VideoListModel>>> GetAllAsync()
    {
        try
        {
            var videos = await _videoService.GetAllVideosAsync();
            return Ok(videos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all videos");
            return BadRequest(ex);
        }
    }

    [HttpGet("fromcategory/{categoryRoute}")]
    public async Task<ActionResult<IReadOnlyCollection<VideoDetailModel>>> GetByCategoryAsync(string categoryRoute)
    {
        try
        {
            var videos = await _videoService.GetVideosFromCategoryAsync(categoryRoute);
            return Ok(videos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video by category");
            return BadRequest(ex);
        }
    }

    [HttpGet("fromcategory/{categoryRoute}/{count}")]
    public async Task<ActionResult<IReadOnlyCollection<VideoDetailModel>>> GetByCategoryAsync(string categoryRoute, int count)
    {
        try
        {
            var videos = await _videoService.GetVideosFromCategoryAsync(count, categoryRoute);
            return Ok(videos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video by category");
            return BadRequest(ex);
        }
    }

    [HttpGet("detail/{videoRoute}")]
    public async Task<ActionResult<VideoDetailModel>> GetByRouteAsync(string videoRoute)
    {
        try
        {
            var video = await _videoService.GetVideoDetailModelAsync(videoRoute);
            return Ok(video);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video by route");
            return BadRequest(ex);
        }
    }

    //TODO: Authorize
    [HttpGet("edit/{videoRoute}")]
    public async Task<ActionResult<VideoEditModel>> GetEditModelByRouteAsync(string videoRoute)
    {
        try
        {
            var video = await _videoService.GetVideoEditModelAsync(videoRoute);
            return Ok(video);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting video edit model by route");
            return BadRequest(ex);
        }
    }

    [HttpPut("edit")]
    public async Task<ActionResult> EditAsync([FromBody] VideoEditModel videoEditModel)
    {
        try
        {
            await _videoService.UpdateVideoAsync(videoEditModel);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error editing video");
            return BadRequest(ex);
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddAsync([FromBody] VideoAddModel videoEditModel)
    {
        try
        {
            await _videoService.AddVideoAsync(videoEditModel);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating video");
            return BadRequest(ex);
        }
    }
}
