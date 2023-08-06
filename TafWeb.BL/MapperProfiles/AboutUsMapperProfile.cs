namespace TafWeb.BL.MapperProfiles;

public class AboutUsMapperProfile : Profile
{
    public AboutUsMapperProfile()
    {
        CreateMap<AboutUs, AboutUsMainPageModel>().ForMember(
            dst => dst.ShortDesctiptionParagraphs,
            config => config.MapFrom(src => SplitByNewLine(src.ShortDesctiption))
        );
        var detailMap = CreateMap<AboutUs, AboutUsDetailModel>().ForMember(
            dst => dst.LongDescriptionParagraphs,
            config => config.MapFrom(src => SplitByNewLine(src.LongDescription))
        );
        //TODO: Users from repository.
        //detailMap.ForMember(
        //  dst => dst.Users,
        //);
        CreateMap<AboutUsEditModel, AboutUs>();
        CreateMap<AboutUs, AboutUsEditModel>();
    }

    private static string[] SplitByNewLine(string text) => text.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
}
