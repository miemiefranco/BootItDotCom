using BookItDotCom.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();
        IEnumerable<Hotel> GetAllIncludeOutlets();
    }
}
