using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookItDotCom.Web.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        string url = "http://localhost:62882/api/hotels/all-available-rooms" +
            "";

        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
