namespace TafWeb.BL.MapperProfiles;

public class FAQMapperProfile : Profile
{
    public FAQMapperProfile()
    {
        CreateMap<FAQ, FAQListModel>();
        CreateMap<FAQ, FAQEditModel>();
        CreateMap<FAQEditModel, FAQ>();
        CreateMap<FAQAddModel, FAQ>();
    }
}
