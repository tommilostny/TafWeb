namespace TafWeb.BL.MapperProfiles;

public class TafUserMapperProfile : Profile
{
    public TafUserMapperProfile()
    {
        CreateMap<TafUser, TafUserListModel>();
        CreateMap<TafUser, TafUserEditModel>();
        CreateMap<TafUserEditModel, TafUser>();
    }
}
