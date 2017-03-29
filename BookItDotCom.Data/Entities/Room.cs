using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }

        public RoomType RoomType { get; set; }

        public decimal Price { get; set; }
    }

    public enum RoomType
    {
      TwimRoom,
      StandardDouble,
      KingRoom,
    }
}
