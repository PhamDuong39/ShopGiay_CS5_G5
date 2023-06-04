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
            string apiDatas = await responses.Content.ReadAsStringAsync(); // doc data tra ve
            var shoeDetails =
                JsonConvert.DeserializeObject<IEnumerable<ShoeDetails>>(apiDatas); // chuyen data thanh list
            return View(shoeDetails);
        }

        //create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShoeDetails shoeDetails, List<Guid> sizesList, List<Guid> colorsList)
        {
            // Check shoeDetails, sizesList, colorsList is null and return BadRequest
            if (shoeDetails == null || sizesList == null || colorsList == null)
            {
                // Print the count of sizes and colors
                return Content($"Size: {sizesList?.Count ?? 0} Color: {colorsList?.Count ?? 0}");
            }
            else
            {
                for (int i = 0; i < sizesList.Count(); i++)
                {
                    for (int j = 0; j < colorsList.Count(); j++)
                    {
                        ShoeDetails newshoes = new ShoeDetails()
                        {
                            Id = Guid.NewGuid(),
                            Name = shoeDetails.Name,
                            CostPrice = shoeDetails.CostPrice,
                            SellPrice = shoeDetails.SellPrice,
                            AvailableQuantity = shoeDetails.AvailableQuantity,
                            Status = shoeDetails.Status,
                            IdSupplier = shoeDetails.IdSupplier,
                            IdCategory = shoeDetails.IdCategory,
                            IdBrand = shoeDetails.IdBrand,
                            IdSale = shoeDetails.IdSale
                        };
                        string urlApi =
                            $"https://localhost:7109/api/ShoeDetails/create-shoeDetails?IDShoeDetails={newshoes.Id}&name={newshoes.Name}&costPrice={newshoes.CostPrice}&sellPrice={newshoes.SellPrice}&availableQuantity={newshoes.AvailableQuantity}&status={newshoes.Status}&idSupplier={newshoes.IdSupplier}&idCategory={newshoes.IdCategory}&idBrand={newshoes.IdBrand}&idSale={newshoes.IdSale}";
                        var response = await _httpClient.PostAsync(urlApi, null);
                        string urlApiSize =
                            $"https://localhost:7109/api/SIzes_ShoeDetails/create-size-shoe-details?sizeId={sizesList[i]}&shoeDetailsId={newshoes.Id}";
                        var responseSize = await _httpClient.PostAsync(urlApiSize, null);
                        string urlApiColor =
                            $"https://localhost:7109/api/Color_ShoeDetails/create-color-shoeDetails?idShoeDetails={newshoes.Id}&idColor={colorsList[j]}";
                        var responseColor = await _httpClient.PostAsync(urlApiColor, null);
                    }
                }
            }

            // Check shoeDetails, sizesList, colorsList is null and return BadRequest
            return RedirectToAction("Show");
        }

        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response =
                await _httpClient.GetAsync($"https://localhost:7109/api/ShoeDetails/get-shoeDetails-by-id?id={id}");
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
            var response =
                await _httpClient.GetAsync($"https://localhost:7109/api/ShoeDetails/get-shoeDetails-by-id?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            var shoeDetails = JsonConvert.DeserializeObject<ShoeDetails>(result);
            if (response.IsSuccessStatusCode)
            {
                return View(shoeDetails);
            }

            return NotFound();
        }

        //delete
        public async Task<IActionResult> Delete(Guid id)
        {
            string apiUrl = $"https://localhost:7109/api/ShoeDetails/delete-shoedetails?id={id}";
            var response = await _httpClient.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("Show");
            }

            return this.RedirectToAction("Show");
        }

        //delete many
        public async Task<IActionResult> DeleteMany(List<Guid> deleteMany)
        {
            foreach (var item in deleteMany)
            {
                string apiUrl = $"https://localhost:7109/api/ShoeDetails/delete-shoedetails?id={item}";
                var response = await _httpClient.DeleteAsync(apiUrl);
            }

            return RedirectToAction("Show");
        }
    }
}