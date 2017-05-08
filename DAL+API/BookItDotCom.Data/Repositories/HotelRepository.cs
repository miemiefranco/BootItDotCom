using System;
using System.Collections.Generic;
using System.Text;
using BookItDotCom.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookItDotCom.Data.Helpers;

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

        public IEnumerable<Room> GetAvailableRoomsWithHotelAndReference(BookingResourceParametersDB bookingResourceParametersDB )
        {
            var rooms = _context.Rooms.Where(r => r.IsOccupied == false)
                   .Include(rf => rf.BookedRoomReferences)
                   .Include(h => h.HotelOutlet)
                   .ToList();

            if(bookingResourceParametersDB.CheckIn != null 
                && bookingResourceParametersDB.CheckOut != null)
            {
                var roomsToRemoveFromDateFilter =  new List<Room>();
                //filter by date
                foreach (var r in rooms)
                {
                    foreach(var br in r.BookedRoomReferences)
                    {
                        bool overlap = br.DateFrom < bookingResourceParametersDB.CheckOut && bookingResourceParametersDB.CheckIn < br.DateTo;
                        if(overlap)
                        {
                            roomsToRemoveFromDateFilter.Add(r);
                        }
                    }
                }

                if(roomsToRemoveFromDateFilter.Count() > 0 )
                {
                    foreach (var rToRemove in roomsToRemoveFromDateFilter)
                    {
                        rooms.RemoveAll(item => item.RoomId == rToRemove.RoomId );
                    }
                }
              
            }

            if(bookingResourceParametersDB.Rating != null)
            {
                //filter by rating
                var roomsToRemoveFromRatingFilter = new List<Room>();

                foreach(var r in rooms)
                {
                    var rating = _context.HotelOutlets.Where(h => h.HotelOutletId == r.HotelOutletRefId)
                        .FirstOrDefault().Rating;

                    if(rating != bookingResourceParametersDB.Rating)
                    {
                        roomsToRemoveFromRatingFilter.Add(r);
                    }

                }

                if(roomsToRemoveFromRatingFilter.Count() > 0)
                {
                    foreach (var rToRemove in roomsToRemoveFromRatingFilter)
                    {
                        rooms.RemoveAll(item => item.RoomId == rToRemove.RoomId);
                    }
                }
               
            }

            return rooms;
        }

        public IEnumerable<HotelOutlet> GetRoomsWithResourceParameeters(BookingResourceParametersDB bookingResourceParametersDB)
        {
            var hotels = _context.HotelOutlets
                .Include(h => h.Address)
                .Include(h => h.Rooms);

            if (bookingResourceParametersDB.CheckIn != null
                && bookingResourceParametersDB.CheckOut != null)
            {
                var hotelsFromDateFilter = new List<HotelOutlet>();

                foreach(var h in hotels)
                {
                    var roomsToRemoveFromDateFilter = new List<Room>();
                    foreach (var r in h.Rooms)
                    {
                        var bookingRefs = GetBookedRoomReference(r.RoomId);
                        
                        foreach(var bRef in bookingRefs)
                        {
                            bool overlap = bRef.DateFrom < bookingResourceParametersDB.CheckOut && bookingResourceParametersDB.CheckIn < bRef.DateTo;
                            if (overlap)
                            {
                                roomsToRemoveFromDateFilter.Add(r);
                            }
                        }
                    }

                    if(roomsToRemoveFromDateFilter.Count() > 0 )
                    {
                        foreach (var rToRemove in roomsToRemoveFromDateFilter)
                        {
                            h.Rooms.Remove(rToRemove);
                        }
                    }
                  
                }
            }

                return hotels.ToList();
        }

        public IEnumerable<HotelOutlet> GetAllHotel()
        {
            return _context.HotelOutlets.Include(h => h.Address).ToList();
        }

        public IEnumerable<BookedRoomReference> GetBookedRoomReference(int roomId)
        {
            return _context.BookedRoomReferences.Where(rf => rf.RoomRefId == roomId).ToList();
        }

    }
}
