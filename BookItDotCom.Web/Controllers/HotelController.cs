using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BookItDotCom.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookItDotCom.Web.Controllers
{
    public class HotelController : Controller
    {
        HttpClient client;
        string url = "http://localhost:62882/api/hotels" +
            "";
        public HotelController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<HotelViewModel> hotels = new List<HotelViewModel>();

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                hotels = JsonConvert.DeserializeObject<List<HotelViewModel>>(responseData);
            }
            return View(hotels);
        }
    }
}
