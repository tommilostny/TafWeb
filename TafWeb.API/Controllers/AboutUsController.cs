using Microsoft.AspNetCore.OutputCaching;

namespace TafWeb.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AboutUsController : ControllerBase
{
    private readonly ILogger<AboutUsController> _logger;
    private readonly IAboutUsService _aboutUsService;
    private readonly IOutputCacheStore _cache;

    public AboutUsController(ILogger<AboutUsController> logger, IAboutUsService aboutUsService, IOutputCacheStore cache)
    {
        _logger = logger;
        _aboutUsService = aboutUsService;
        _cache = cache;
    }

    [HttpGet]
    [Route("main")]
    [OutputCache(PolicyName = "AboutUsMainPage")]
    public async Task<ActionResult<AboutUsMainPageModel>> GetMainPageModelAsync()
    {
        try
        {
            var aboutUsMainPageModel = await _aboutUsService.GetMainPageModelAsync();
            return Ok(aboutUsMainPageModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in AboutUsController.GetMainPageModelAsync()");
            return BadRequest(ex);
        }
    }

    [HttpGet]
    [Route("detail")]
    [OutputCache(PolicyName = "AboutUsDetailPage")]
    public async Task<ActionResult<AboutUsDetailModel>> GetDetailModelAsync()
    {
        try
        {
            var aboutUsDetailModel = await _aboutUsService.GetDetailModelAsync();
            return Ok(aboutUsDetailModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in AboutUsController.GetDetailModelAsync()");
            return BadRequest(ex);
        }
    }

    [HttpPut]
    [Route("edit")]
    public async Task<ActionResult> EditAsync([FromBody] AboutUsEditModel aboutUsEditModel)
    {
        try
        {
            await _aboutUsService.UpdateAboutUsAsync(aboutUsEditModel);
            await _cache.EvictByTagAsync("AboutUs", default);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in AboutUsController.EditAsync()");
            return BadRequest(ex);
        }
    }
}
