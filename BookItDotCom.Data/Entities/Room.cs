using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }      
        public string Floor { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public bool IsOccupied { get; set; }

        public int HotelOutletRefId { get; set; }
        [ForeignKey("HotelOutletRefId")]
        public virtual HotelOutlet HotelOutlet { get; set; }

        public int? BookedRoomRefId { get; set; }
        [ForeignKey("RoomRefId")]
        public BookedRoomReference BookedRoomReference { get; set; }

    }

    public enum RoomType
    {
      TwimRoom,
      StandardDouble,
      KingRoom,
    }
}
