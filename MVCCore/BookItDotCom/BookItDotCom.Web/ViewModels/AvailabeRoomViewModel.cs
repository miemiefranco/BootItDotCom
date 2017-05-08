using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class AvailabeRoomViewModel
    {
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsOccupied { get; set; }
        public decimal Price { get; set; }
       //public OutletViewModel HotelOutletID { get; set; }
       // public List<BookedRoomReferenceViewModel> BookedRoomReferences { get; set; }
    }

    public enum RoomType
    {
        TwimRoom,
        StandardDouble,
        KingRoom,
    }
}
