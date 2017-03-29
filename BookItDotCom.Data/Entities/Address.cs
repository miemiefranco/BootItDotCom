using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class Address
    {
        [Key]
        public int AddresId { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressLine3 { get; set; }
        public String PostCode { get; set; }
        public String Town { get; set; }
        public String State { get; set; }
        public String Country { get; set; }       
        public HotelOutlet HotelOutlet { get; set; }
    }
}
