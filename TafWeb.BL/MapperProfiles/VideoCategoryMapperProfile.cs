namespace TafWeb.BL.MapperProfiles;

public class VideoCategoryMapperProfile : Profile
{
    public VideoCategoryMapperProfile()
    {
        CreateMap<VideoCategory, VideoCategoryListModel>();
        CreateMap<VideoCategory, VideoCategoryDetailModel>();
        CreateMap<VideoCategory, VideoCategoryEditModel>();
        CreateMap<VideoCategoryEditModel, VideoCategory>();
    }
}
