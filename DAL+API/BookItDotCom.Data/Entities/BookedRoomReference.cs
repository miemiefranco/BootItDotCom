using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookItDotCom.Data.Entities
{
    public class BookedRoomReference
    {
        public int BookedRoomReferenceId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int? RoomRefId { get; set; }
        [ForeignKey("RoomRefId")]
        public virtual Room Room { get; set; }

    }
}
