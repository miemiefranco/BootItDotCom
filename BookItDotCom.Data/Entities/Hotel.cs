using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class Hotel
    {
        public Hotel()
        {
            Outlets = new List<HotelOutlet>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int NumberOfOutlet { get; set; }
        public virtual ICollection<HotelOutlet> Outlets { get; set; }

    }
}
