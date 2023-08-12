namespace TafWeb.BL.MapperProfiles;

public class VideoCategoryMapperProfile : Profile
{
    public VideoCategoryMapperProfile()
    {
        CreateMap<VideoCategory, VideoCategoryListModel>();
        CreateMap<VideoCategory, VideoCategoryDetailModel>()
            .ForMember(
                dst => dst.Videos,
                config => config.Ignore()
            );
        CreateMap<VideoCategory, VideoCategoryEditModel>();
        CreateMap<VideoCategoryEditModel, VideoCategory>();
    }
}
