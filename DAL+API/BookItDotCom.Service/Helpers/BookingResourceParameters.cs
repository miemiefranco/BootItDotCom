using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Helpers
{
    public class BookingResourceParameters
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Rating { get; set; }
    }
}
