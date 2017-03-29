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

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public IEnumerable<Hotel> GetAllIncludeOutlets()
        {
            return _context.Hotels.Include(h => h.Outlets).ToList();
        }
    }
}
