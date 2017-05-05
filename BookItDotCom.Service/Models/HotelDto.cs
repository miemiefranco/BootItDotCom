using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Models
{
    public class HotelDto
    {
        public string HotelOutletName { get; set; }
        public int Rating { get; set; }       
        public ModelAddress Address { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
