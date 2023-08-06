namespace TafWeb.BL.MapperProfiles;

public class ClientFeedbackMapperProfile : Profile
{
    public ClientFeedbackMapperProfile()
    {
        CreateMap<ClientFeedback, ClientFeedbackListModel>();
        CreateMap<ClientFeedbackAddModel, ClientFeedback>();
    }
}
