using System.Text;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectViews.Controllers
{
    public class SupplierController : Controller
    {
        private readonly HttpClient _httpClient;

        public SupplierController()
        {
            _httpClient = new HttpClient();
        }
        //show
        public async Task<IActionResult> Show()
        {
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/Suppliers/get-all-supplier");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync(); //read the response as string
                var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(result); //convert the string into list of suppliers
                return View(suppliers);
            }
            return NotFound();
        }
        //create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            var content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7109/api/Suppliers/create-supplier", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Show");
            }
            return View();
        }
        //details
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/Suppliers/get-supplier-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var supplier = JsonConvert.DeserializeObject<Supplier>(result);
                return View(supplier);
            }

            return NotFound();
        }
        //update
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            //get supplier by id
            var response = await _httpClient.GetAsync($"https://localhost:7109/api/Suppliers/get-supplier-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var supplier = JsonConvert.DeserializeObject<Supplier>(result);
                return View(supplier);
            }
            return this.RedirectToAction("Show");
        }
        [HttpPost]
        public async Task<IActionResult> Update(Supplier supplier)
        {
            var content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:7109/api/Suppliers/update-supplier", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Show");
            }
            return View();
        }
        //delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7109/api/Suppliers/delete-supplier/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Show");
            }
            return NotFound();
        }
    }
}
