using AutoMapper;
using Domain;

namespace API;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<ActivityDTO, Activity>().ReverseMap();
    }
}
