namespace TafWeb.BL.MapperProfiles;

public class AboutUsMapperProfile : Profile
{
    public AboutUsMapperProfile()
    {
        CreateMap<AboutUs, AboutUsMainPageModel>();
        CreateMap<AboutUs, AboutUsDetailModel>();
        
        CreateMap<AboutUsEditModel, AboutUs>()
            .ForMember(
                dst => dst.ShortDesctiptionParagraphs,
                config => config.MapFrom(src => SplitByNewLine(src.ShortDesctiption))
            )
            .ForMember(
                dst => dst.LongDescriptionParagraphs,
                config => config.MapFrom(src => SplitByNewLine(src.LongDescription))
            );
        
        CreateMap<AboutUs, AboutUsEditModel>()
            .ForMember(
                dst => dst.ShortDesctiption,
                config => config.MapFrom(src => JoinByNewLine(src.ShortDesctiptionParagraphs))
            )
            .ForMember(
                dst => dst.LongDescription,
                config => config.MapFrom(src => JoinByNewLine(src.LongDescriptionParagraphs))
            );
    }

    private static string[] SplitByNewLine(string text) => text.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    private static string JoinByNewLine(string[] paragraphs) => string.Join('\n', paragraphs);
}
