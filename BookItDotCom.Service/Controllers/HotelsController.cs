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

        // GET api/hotels
        [HttpGet]
        public IActionResult Get(bool IncludeOutlet = false)
        {
            var hotels = _hotelRepo.GetAllIncludeOutlets();
            return Ok(_mapper.Map<IEnumerable<ModelHotel>>(hotels));
        }

    }
}
