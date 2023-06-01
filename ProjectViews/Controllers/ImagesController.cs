using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectViews.Controllers
{
    public class ImagesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ImagesController()
        {
            _httpClient = new HttpClient();
        }
        // GET: ImageController
        public async Task<IActionResult> Show()
        {
            string apiUrl = $"https://localhost:7109/api/Images/get-all-image";
            var response = await _httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var images = JsonConvert.DeserializeObject<IEnumerable<Images>>(apiData);
            return View(images);
        }
        //create

        public IActionResult Create()
        {
            return View();
        }
        //details
        public async Task<IActionResult> Detail(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/Images/get-image-by-id?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            var image = JsonConvert.DeserializeObject<Images>(result);
            if (response.IsSuccessStatusCode)
            {
                return View(image);
            }
            return NotFound();
        }
        //update
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            //get supplier by id
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/Images/get-image-by-id?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            var image = JsonConvert.DeserializeObject<Images>(result);
            if (response.IsSuccessStatusCode)
            {
                return View(image);
            }
            return NotFound();
        }
    }
}
