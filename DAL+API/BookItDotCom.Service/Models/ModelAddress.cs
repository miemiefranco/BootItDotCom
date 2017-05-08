using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Service.Models
{
    public class ModelAddress
    {
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressLine3 { get; set; }
        public String PostCode { get; set; }
        public String Town { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
    }
}
