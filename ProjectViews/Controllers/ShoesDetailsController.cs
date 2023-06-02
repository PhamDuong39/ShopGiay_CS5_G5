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
            //check shoeDetails, sizesList, colorsList is null return badrequest
            if (shoeDetails == null || sizesList == null || colorsList == null)
            {
                return Content($"Size : {sizesList.Count} Color : {colorsList.Count}");
            }
            else
            {
                //Vd Đầu vào là 1 shoeDetails, 1 list size bao gồm 5 size, 1 list color 5 color thì sẽ tạo ra 25 ShoeDetails mới và tương đương 25 size_shoeDetaisl và 25 color_shoeDetails
                //Tạo ra 1 list shoeDetails mới
                //Duyệt qua từng size trong list size
                foreach (var size in sizesList)
                {
                    //Duyệt qua từng color trong list color
                    foreach (var color in colorsList)
                    {
                        //Tạo ra 1 shoeDetails mới
                        var newShoeDetails = new ShoeDetails()
                        {
                            Id = Guid.NewGuid(),
                            IdSupplier = shoeDetails.IdSupplier,
                            IdCategory = shoeDetails.IdCategory,
                            IdBrand = shoeDetails.IdBrand,
                            Name = shoeDetails.Name,
                            CostPrice = shoeDetails.CostPrice,
                            SellPrice = shoeDetails.SellPrice,
                            AvailableQuantity = shoeDetails.AvailableQuantity,
                            Status = shoeDetails.Status,
                            IdSale = shoeDetails.IdSale
                        };
                        //Thêm shoeDetails mới vào database
                        string urlApi =
                            $"https://localhost:7109/api/ShoeDetails/create-shoeDetails?name={newShoeDetails.Name}&costPrice={newShoeDetails.CostPrice}&sellPrice={newShoeDetails.SellPrice}&availableQuantity={newShoeDetails.AvailableQuantity}&status={newShoeDetails.Status}&idSupplier={newShoeDetails.IdSupplier}&idCategory={newShoeDetails.IdCategory}&idBrand={newShoeDetails.IdBrand}&idSale={newShoeDetails.IdSale}";
                        var response = await _httpClient.PostAsync(urlApi, null);
                        //tao mới size_shoesDetails
                        string urlApiSize =
                            $"https://localhost:7109/api/SIzes_ShoeDetails/create-size-shoe-details?sizeId={size}&shoeDetailsId={newShoeDetails.Id}";
                        var responseSize = await _httpClient.PostAsync(urlApiSize, null);
                        //Thêm  mới vào list shoeDetails
                        string urlApiColor =
                            $"https://localhost:7109/api/Color_ShoeDetails/create-color_shoeDetails?idShoeDetails={newShoeDetails.Id}&idColor={color}";
                        var responseColor = await _httpClient.PostAsync(urlApiColor, null);
                    }
                }
            }
            //check shoeDetails, sizesList, colorsList is null return badrequest
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