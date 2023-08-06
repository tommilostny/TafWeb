namespace TafWeb.BL.MapperProfiles;

public class OrderFormEntryMapperProfile : Profile
{
    public OrderFormEntryMapperProfile()
    {
        CreateMap<OrderFormEntry, OrderFormEntryListModel>();
        CreateMap<OrderFormEntry, OrderFormEntryDetailModel>();
        CreateMap<OrderFormEntryAddModel, OrderFormEntry>();
    }
}
