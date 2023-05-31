using System.Text;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectViews.Controllers
{
    public class BrandsController : Controller
    {
        private readonly HttpClient _httpClient;

        public BrandsController()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<IActionResult> Show()
        {
            string apiUrl = "https://localhost:7109/api/Brand/get-all-brands";
            var response = await _httpClient.GetAsync(apiUrl);
            string apidata = await response.Content.ReadAsStringAsync();
            var brd = JsonConvert.DeserializeObject<IEnumerable<Brands>>(apidata);
            //check if brd is null
            if (brd == null)
            {
                return this.BadRequest();
            }
            return View(brd);
        }

        public IActionResult Create()
        {
            return View();
        }
        //create
        [HttpPost]
        public async Task<IActionResult> Create(Brands brands)
        {
            string apiUrl = $"https://localhost:7109/api/Brand/create-brand?brandName={brands.Name}";
            var content = new StringContent(JsonConvert.SerializeObject(brands), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("Show");
            }
            return this.View();
        }
        //details
        public async Task<IActionResult> Detail(Guid id)
        {
            string apiUrl = $"https://localhost:7109/api/Brand/get-brand-by-id?id={id}";
            var response = await _httpClient.GetAsync(apiUrl);
            string apidata = await response.Content.ReadAsStringAsync();

            var brd = JsonConvert.DeserializeObject<Brands>(apidata);
            return View(brd);
        }
        //update
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            string apiUrl = $"https://localhost:7109/api/Brand/get-brand-by-id?id={id}";
            var response = await _httpClient.GetAsync(apiUrl);
            string apidata = await response.Content.ReadAsStringAsync();

            var brd = JsonConvert.DeserializeObject<Brands>(apidata);
            return View(brd);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Brands brands)
        {
            string apiUrl = $"https://localhost:7109/api/Brand/update-brand-by-id?id={brands.Id}&brandName={brands.Name}";
            var content = new StringContent(JsonConvert.SerializeObject(brands), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("Show");
            }
            return this.View();
        }
        //delete
        public async Task<IActionResult> Delete(Guid id)
        {
            string apiUrl = $"https://localhost:7109/api/Brand/delete-brands-by-id?id={id}";
            var response = await _httpClient.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("Show");
            }
            return this.RedirectToAction("Show");
        }
    }

}
