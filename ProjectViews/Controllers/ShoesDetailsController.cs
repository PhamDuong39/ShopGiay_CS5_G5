using System.Text;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectViews.Models;

namespace ProjectViews.Controllers
{
    public class ShoesDetailsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ShoesDetailsController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Show()
        {
            //Lay List Shoes Detail
            string apiUrls = $"https://localhost:7109/api/ShoeDetails/get-all-shoeDetails";
            var responses = await _httpClient.GetAsync(apiUrls); // goi api lay data
            string apiDatas = await responses.Content.ReadAsStringAsync();// doc data tra ve
            var shoeDetails = JsonConvert.DeserializeObject<IEnumerable<ShoeDetails>>(apiDatas); // chuyen data thanh list
            return View(shoeDetails);
        }
        //create
        public IActionResult Create()
        {
            return View();
        }
        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/ShoeDetails/get-shoeDetails-by-id?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            var shoeDetails = JsonConvert.DeserializeObject<ShoeDetails>(result);
            if (response.IsSuccessStatusCode)
            {
                return View(shoeDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShoeDetails shoeDetails)
        {

            return View(shoeDetails);
        }
        //details
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/ShoeDetails/get-shoeDetails-by-id?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            var shoeDetails = JsonConvert.DeserializeObject<ShoeDetails>(result);
            if (response.IsSuccessStatusCode)
            {
                return View(shoeDetails);
            }
            return NotFound();
        }
    }
}
