namespace TafWeb.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AboutUsController : ControllerBase
{
    private readonly ILogger<AboutUsController> _logger;
    private readonly IAboutUsService _aboutUsService;

    public AboutUsController(ILogger<AboutUsController> logger, IAboutUsService aboutUsService)
    {
        _logger = logger;
        _aboutUsService = aboutUsService;
    }

    [HttpGet]
    [Route("main")]
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
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in AboutUsController.EditAsync()");
            return BadRequest(ex);
        }
    }
}
