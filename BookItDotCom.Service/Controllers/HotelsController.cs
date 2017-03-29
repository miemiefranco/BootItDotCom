using AutoMapper;
using BookItDotCom.Data.Repositories;
using BookItDotCom.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepo, 
            IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }

        //GET api/hotels/allmains
        [HttpGet("allmains")]
        public IActionResult Get(bool IncludeOutlet = false)
        {
            var hotels = _hotelRepo.GetMainHotelAllIncludeOutlets();
            return Ok(_mapper.Map<IEnumerable<ModelHotel>>(hotels));
        }


       //GET api/hotels/all
       [HttpGet("all")]
        public IActionResult Get()
        {
            var hotels = _hotelRepo.GetAllHotel();
            return Ok(_mapper.Map<IEnumerable<ModelHotelOutlet>>(hotels));
        }

        //GET api/hotels/all-available-rooms
        [HttpGet("all-available-rooms")]
        public IActionResult GetRooms()
        {
            var rooms = _hotelRepo.GetAvailableRooms();
            return Ok(_mapper.Map<IEnumerable<ModelRoom>>(rooms));
        }

    }
}
