
using AutoMapper;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.Event;
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, GetUserVM>().ReverseMap();
            CreateMap<Feedback, GetFeedbackVM>().ForMember(dest => dest.UserName,
               opt => opt.MapFrom(src => src.User.first_name + " " + src.User.last_name))
           .ReverseMap();

            CreateMap<Chef, CreateChefVM>().ReverseMap();
            CreateMap<Chef, EditChefVM>().ReverseMap();
            CreateMap<Chef, GetChefVM>().ReverseMap();

            CreateMap<Event, CreateEventVM>().ReverseMap();
            CreateMap<Event, EditEventVM>().ReverseMap();
            CreateMap<Event, GetEventVM>().ReverseMap();
        }
    }
}
