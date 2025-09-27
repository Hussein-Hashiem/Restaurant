
using AutoMapper;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.Event;
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.ModelVM.Item;
using Restaurnat.BLL.ModelVM.Menu;
using Restaurnat.BLL.ModelVM.Payment;
using Restaurnat.BLL.ModelVM.Reservation;
using Restaurnat.BLL.ModelVM.Restaurant;
using Restaurnat.BLL.ModelVM.Table;
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
            CreateMap<Feedback, CreateFeedbackVM>().ReverseMap();



            CreateMap<Payment, CreatePaymentVM>().ReverseMap();
            CreateMap<Payment, GetAllPaymentVM>().ReverseMap();
            CreateMap<Payment, GetPaymentVM>().ReverseMap();
            CreateMap<Payment, UpdatePaymentVM>().ReverseMap();

            CreateMap<Chef, CreateChefVM>().ReverseMap();
            CreateMap<Chef, EditChefVM>().ReverseMap();
            CreateMap<Chef, GetChefVM>().ReverseMap();

            CreateMap<Event, CreateEventVM>().ReverseMap();
            CreateMap<Event, EditEventVM>().ReverseMap();
            CreateMap<Event, GetEventVM>().ReverseMap();

            CreateMap<Item, GetItemVM>().ReverseMap();
            CreateMap<Item, List<GetItemVM>>().ReverseMap();
            CreateMap<Item, UpdateItemVM>().ReverseMap();



            CreateMap<Menu, GetMenuVM>().ReverseMap();
            CreateMap<Menu, List<GetMenuVM>>().ReverseMap();

            CreateMap<Reservation, GetReservationVM>().ReverseMap();
            CreateMap<Reservation, List<GetReservationVM>>().ReverseMap();

            CreateMap<Table, GetTableVM>().ReverseMap();
            CreateMap<Table, List<GetTableVM>>().ReverseMap();
            CreateMap<Table, CreateTableVM>().ReverseMap();
            CreateMap<Table, UpdateTableVM>().ReverseMap();

            CreateMap<Item, CreateItemVM>().ReverseMap();
            CreateMap<Item, UpdateItemVM>().ReverseMap();
            CreateMap<Item, GetItemVM>().ReverseMap();
        }
    }
}