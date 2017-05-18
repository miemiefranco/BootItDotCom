using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using BookItDotCom.Web.ViewModels;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookItDotCom.Web.Controllers
{
    public class BookingController : Controller
    {
        HttpClient client;
        string baseUrl = "http://localhost:62882/api/hotels/all-available-rooms" +
            "";

        public BookingController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()

        {
            List<OutletViewModel> model = new List<OutletViewModel>();

            HttpResponseMessage responseMessage = await client.GetAsync(baseUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<OutletViewModel>>(responseData);
            }
            return View(model);
        }


        public async Task<IActionResult> SearchResult(BookingResourceParameters bookingResourceParamenter)
        {
            SearchResultViewModel model = new SearchResultViewModel();

            List<OutletViewModel> hotelResults = new List<OutletViewModel>();

            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(baseUrl);

            if (bookingResourceParamenter.CheckIn != null && bookingResourceParamenter.CheckOut != null)
            {
                String datesQueryString = $"?checkIn={ bookingResourceParamenter.CheckIn.ToString("s") }&checkOut={bookingResourceParamenter.CheckOut.ToString("s")}";
                urlBuilder.Append(datesQueryString);
            }
            bookingResourceParamenter.AvaliableStarRating = GetRatings();

            HttpResponseMessage responseMessage = await client.GetAsync(urlBuilder.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                hotelResults = JsonConvert.DeserializeObject<List<OutletViewModel>>(responseData);
            }

            model.hotels = hotelResults;
            model.bookingResourceParameters = bookingResourceParamenter;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSearchResult(BookingResourceParameters bookingResourceParamenter)
        {
            SearchResultViewModel model = new SearchResultViewModel();

            List<OutletViewModel> hotelResults = new List<OutletViewModel>();

            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(baseUrl);

            if (bookingResourceParamenter.CheckIn != null && bookingResourceParamenter.CheckOut != null)
            {
                String datesQueryString = $"?checkIn={ bookingResourceParamenter.CheckIn.ToString("s") }&checkOut={bookingResourceParamenter.CheckOut.ToString("s")}";
                urlBuilder.Append(datesQueryString);
            }

            if (!String.IsNullOrEmpty(bookingResourceParamenter.SelectedStarRatingString))
            {
                urlBuilder.Append ($"&rating={bookingResourceParamenter.SelectedStarRatingString}");
            }

            HttpResponseMessage responseMessage = await client.GetAsync(urlBuilder.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                hotelResults = JsonConvert.DeserializeObject<List<OutletViewModel>>(responseData);
            }

            model.hotels = hotelResults;
            model.bookingResourceParameters = bookingResourceParamenter;

            return PartialView("__SearchResultHotelList", model);
        }

        private IList<SelectListItem> GetRatings()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "1", Value = "1"},
                new SelectListItem {Text = "2", Value = "2"},
                new SelectListItem {Text = "3", Value = "3"},
                new SelectListItem {Text = "4", Value = "4"},
                new SelectListItem {Text = "5", Value = "5"},
            };
        }
    }


}
