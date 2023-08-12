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
                config => config.MapFrom(src => Utils.SplitByNewLine(src.ShortDesctiption))
            )
            .ForMember(
                dst => dst.LongDescriptionParagraphs,
                config => config.MapFrom(src => Utils.SplitByNewLine(src.LongDescription))
            );
        
        CreateMap<AboutUs, AboutUsEditModel>()
            .ForMember(
                dst => dst.ShortDesctiption,
                config => config.MapFrom(src => Utils.JoinByNewLine(src.ShortDesctiptionParagraphs))
            )
            .ForMember(
                dst => dst.LongDescription,
                config => config.MapFrom(src => Utils.JoinByNewLine(src.LongDescriptionParagraphs))
            );
    }
}
