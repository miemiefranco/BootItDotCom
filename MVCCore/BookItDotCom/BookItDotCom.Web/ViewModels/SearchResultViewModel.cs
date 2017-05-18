using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public SearchResultViewModel()
        {
            hotels = new List<OutletViewModel>();
        }
        public List<OutletViewModel> hotels { get; set; }
        public BookingResourceParameters bookingResourceParameters { get; set; }
    }
}
