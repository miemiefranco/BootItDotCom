using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class BookingResourceParameters
    {
        
        [Required]
        public String Location { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public decimal? Rating { get; set; }
        public int Room { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChild { get; set; } = 0;
    }
}
