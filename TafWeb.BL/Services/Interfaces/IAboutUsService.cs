namespace TafWeb.BL.Services.Interfaces;

public interface IAboutUsService
{
    Task<AboutUsMainPageModel> GetMainPageModelAsync();
    Task<AboutUsDetailModel> GetDetailModelAsync();
    Task UpdateAboutUsAsync(AboutUsEditModel model);
}
