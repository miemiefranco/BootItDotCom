using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Models
{
    public class ModelHotel
    {
        public string HotelName { get; set; }
        public int NumberOfOutlet { get; set; }
        public List<ModelHotelOutlet> Outlets { get; set; }
    }
}
