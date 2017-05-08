using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class HotelViewModel
    {
        public string HotelName { get; set; }
        public int NumberOfOutlet { get; set; }
        public List<OutletViewModel> Outlets { get; set; }
    }
}
