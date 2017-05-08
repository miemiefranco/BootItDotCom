using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class HotelOutlet
    {
        public HotelOutlet()
        {
            Rooms = new List<Room>();
        }

        public int HotelOutletId { get; set; }
        public string HotelOutletName { get; set; }
        public int Rating { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        public int AddressRef { get; set; }
        [ForeignKey("AddressRef")]
        public  Address Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }


    }
}
