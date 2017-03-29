using BookItDotCom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetMainHotelAll();
        IEnumerable<Hotel> GetMainHotelAllIncludeOutlets();

        IEnumerable<HotelOutlet> GetAllHotel();

        IEnumerable<Room> GetAvailableRooms();
        IEnumerable<Room> GetAvailableRoomsWithReference();
    }
}
