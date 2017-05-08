using BookItDotCom.Data.Entities;
using BookItDotCom.Data.Helpers;
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
        IEnumerable<Room> GetAvailableRoomsWithHotelAndReference(BookingResourceParametersDB bookingResourceParametersDB);
        IEnumerable<HotelOutlet> GetRoomsWithResourceParameeters(BookingResourceParametersDB bookingResourceParametersDB);

        IEnumerable<BookedRoomReference> GetBookedRoomReference(int roomId);
    }
}
