namespace TafWeb.BL.MapperProfiles;

public class VideoMapperProfile : Profile
{
    public VideoMapperProfile()
    {
        CreateMap<Video, VideoListModel>();
        CreateMap<Video, VideoDetailModel>();
        CreateMap<Video, VideoEditModel>();
        CreateMap<VideoEditModel, Video>();
        CreateMap<VideoAddModel, Video>();
    }
}
