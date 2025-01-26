using AutoMapper;
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Web.Areas.Admin.Models.MeetingRoomModels;

namespace MeetingRoomBookingSystem.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<MeetingRoomCreateModel, MeetingRoom>().ReverseMap();

        }
    }
}
