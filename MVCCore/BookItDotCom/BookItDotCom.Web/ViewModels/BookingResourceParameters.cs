using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.ViewModels
{
    public class BookingResourceParameters
    {
        public BookingResourceParameters()
        {
            SelectedStarRating = new List<string>();
        }
        
        [Required]
        public String Location { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public string SelectedStarRatingString { get; set; }
        public IList<string> SelectedStarRating { get; set; }
        public IList<SelectListItem> AvaliableStarRating { get; set; }
        public int Room { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChild { get; set; } = 0;
    }
}


public class Rating {
   public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSelected { get; set; }
}


