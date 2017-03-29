using AutoMapper;
using BookItDotCom.Data.Entities;
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
        }
    }
}
