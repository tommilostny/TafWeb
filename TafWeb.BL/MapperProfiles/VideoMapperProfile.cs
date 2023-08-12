namespace TafWeb.BL.MapperProfiles;

public class VideoMapperProfile : Profile
{
    public VideoMapperProfile()
    {
        CreateMap<Video, VideoListModel>()
            .ForMember(
                dst => dst.ThumbnailBase64,
                config => config.Ignore()
            );
        CreateMap<Video, VideoDetailModel>();
        CreateMap<Video, VideoEditModel>();
        CreateMap<VideoEditModel, Video>();
        CreateMap<VideoAddModel, Video>();
    }
}
