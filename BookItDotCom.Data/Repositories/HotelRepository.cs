using System;
using System.Collections.Generic;
using System.Text;
using BookItDotCom.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookItDotCom.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetMainHotelAll()
        {
            return _context.Hotels.ToList();
        }

        public IEnumerable<Hotel> GetMainHotelAllIncludeOutlets()
        {
            return _context.Hotels.Include(h => h.Outlets).ToList();
        }

        public IEnumerable<Room> GetAvailableRooms()
        {
           return _context.Rooms.Where(r => r.IsOccupied == false).ToList();
        }

        public IEnumerable<Room> GetAvailableRoomsWithReference()
        {
            return _context.Rooms.Where(r => r.IsOccupied == false).Include(rf => rf.BookedRoomReference).ToList();
        }

        public IEnumerable<HotelOutlet> GetAllHotel()
        {
            return _context.HotelOutlets.Include(h => h.Address).ToList();
        }
    }
}
