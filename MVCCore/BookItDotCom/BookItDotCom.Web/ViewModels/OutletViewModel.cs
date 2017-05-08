using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class OutletViewModel
    {
        public string HotelOutletName { get; set; }
        public int Rating { get; set; }
        public AddressViewModel Address { get; set; }
        public List<AvailabeRoomViewModel> Rooms { get; set; }
    }
}
