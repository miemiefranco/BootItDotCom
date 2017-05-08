using AutoMapper;
using BookItDotCom.Data.Entities;
using BookItDotCom.Data.Helpers;
using BookItDotCom.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile() : this ("MyProfile")
        {

        }

        protected MapperProfile(string profileName) 
            : base(profileName)
        {
            CreateMap<Hotel, ModelHotel>();
            CreateMap<HotelOutlet, ModelHotelOutlet>();
            CreateMap<Address, ModelAddress>();
            CreateMap<Room, ModelRoom>()
                .ForMember(r=>r.HotelOutletID, mr=>mr.MapFrom(m=>m.HotelOutletRefId));
            CreateMap<BookedRoomReference, ModelBookedRoomReference>();
            CreateMap<BookingResourceParameters, BookingResourceParametersDB>();
            CreateMap<Room, RoomDto>();
            CreateMap<HotelOutlet,HotelDto>();
        }
    }
}
