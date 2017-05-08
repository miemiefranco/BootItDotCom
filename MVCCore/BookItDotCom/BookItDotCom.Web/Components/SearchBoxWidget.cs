using BookItDotCom.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookItDotCom.Web.Components
{
    public class SearchBoxWidget : ViewComponent
    {
        public SearchBoxWidget()
        {
                
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SearchCriteria();
            return View(model);
        }
    }

    public class SearchCriteria
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
