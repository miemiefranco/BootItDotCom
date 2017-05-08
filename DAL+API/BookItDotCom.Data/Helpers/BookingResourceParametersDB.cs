using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data.Helpers
{
    public class BookingResourceParametersDB
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal? Rating { get; set; }
    }
}
