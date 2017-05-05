using BookItDotCom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Models
{
    public class RoomDto
    {
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public bool IsOccupied { get; set; }
        public ModelHotel HotelOutletID { get; set; }
        public ModelAddress Address { get; set; }
        public virtual List<ModelBookedRoomReference> BookedRoomReferences { get; set; }
    }
}
