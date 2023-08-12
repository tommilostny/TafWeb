namespace TafWeb.BL.MapperProfiles;

public class VideoCategoryMapperProfile : Profile
{
    public VideoCategoryMapperProfile()
    {
        CreateMap<VideoCategory, VideoCategoryListModel>()
            .ForMember(
                dst => dst.Paragraphs,
                config => config.MapFrom(src => src.MainPageParagraphs));

        CreateMap<VideoCategory, VideoCategoryDetailModel>()
            .ForMember(
                dst => dst.Videos,
                config => config.Ignore())
            .ForMember(
                dst => dst.Faqs,
                config => config.Ignore())
            .ForMember(
                dst => dst.Paragraphs,
                config => config.MapFrom(src => src.DetaiPageParagraphs));

        CreateMap<VideoCategory, VideoCategoryEditModel>()
            .ForMember(
                dst => dst.MainPageText,
                config => config.MapFrom(src => Utils.JoinByNewLine(src.MainPageParagraphs)))
            .ForMember(
                dst => dst.DetailPageText,
                config => config.MapFrom(src => Utils.JoinByNewLine(src.DetaiPageParagraphs)));

        CreateMap<VideoCategoryEditModel, VideoCategory>()
            .ForMember(
                dst => dst.MainPageParagraphs,
                config => config.MapFrom(src => Utils.SplitByNewLine(src.MainPageText)))
            .ForMember(
                dst => dst.DetaiPageParagraphs,
                config => config.MapFrom(src => Utils.SplitByNewLine(src.DetailPageText)));
    }
}
