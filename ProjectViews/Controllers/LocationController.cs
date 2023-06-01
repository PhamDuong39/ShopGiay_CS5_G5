using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectViews.Controllers
{
    public class LocationController  :Controller
    {
        private readonly HttpClient _httpClient;
        public LocationController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> ShowAllLocation()
        {
            // Call API
            string apiUrl = $"https://localhost:7109/api/Location";
            
            var response = await _httpClient.GetAsync(apiUrl);
            string apidata = await response.Content.ReadAsStringAsync();

            var locations = JsonConvert.DeserializeObject<List<Location>>(apidata);
            return View(locations);

            // ASync Await

            /*Là 1 cơ chế quan trọng , rất phổ biến trong Lập trình web được sử dụng để tăng hiệu suất của các chương trình
             * bằng cách khoong cho phép tài nguyền xử lí được nghỉ ngơi mà không hoạt động
             * Khi Client tạo ra 1 Request thì sẽ có 1 luồng chính được thực thi. Luồng chính đó có thể chưa nhiều luồng 
             * phụ. Các luongf phụ này sẽ không chạy tuần tự mà thực hiện luân phiên cho tới khi hoàn thành tất cả. Trong 
             * thời điểm đó, luồng chính sẽ bị block đến thời điểm các luồng con được xử lý hoàn toàn.
             * VD : 
             * Khi thực hiện luồng thanh toán thì có các TASK :
                - Tạo 1 HD trên DB
                - Trừ SL sản phẩm trong DB
                - Clear giỏ hàng
                - Update thêm lịch sử mua hàng
                - Trừ tiền (Nếu có)
                - Tăng điểm cho khách (Nếu có)

               CÓ nhiều cách để cơ chế Async được thực hiện và với cơ chế sử dụng THREAD POOL thì sẽ có nhiều THREAD cùng hoạt
            động để xử lý 1 yc. Nếu Số lượng THREAD nhỏ hơn số lượng Request thì sẽ không có THREAD nào trong trạng thái nghỉ
            mà sẽ luân phiên thực hiện các TASK cho đến khi tất cả thành công.

             
             
             */
        }

        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(Location location)
        {
            //string apiURL = $"https://localhost:7109/api/Location?stage={location.Stage}&District={location.District}&ward={location.Ward}&street={location.Street}&Address={location.Address}";          
            //var response = await _httpClient.PostAsync(apiURL, null);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("ShowAllLocation");
            //}


            string apiURL = $"https://localhost:7109/api/Location/Createlocation?stage={location.Stage}&District={location.District}&ward={location.Ward}&street={location.Street}&Address={location.Address}";
            var content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
            var response1 = await _httpClient.PostAsync(apiURL, content);


            if (response1.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllLocation");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailLocation(Guid Id)
        {
            string apiURL = $"https://localhost:7109/api/Location/{Id}";
            var response = await _httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<Location>(apidata);
            return View(location);
        }

        [HttpGet]
        public async Task<IActionResult> EditLocation(Guid Id)
        {
            string apiURL = $"https://localhost:7109/api/Location/{Id}";
            var response = await _httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<Location>(apidata);
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(Guid Id, Location location)
        {
            string apiURL = $"https://localhost:7109/api/Location/updateLocation?Id={Id}&stage={location.Stage}&District={location.District}&ward={location.Ward}&street={location.Street}&Address={location.Address}";
            var content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("ShowAllLocation");
            }
            return this.View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLocation(Guid Id)
        {
            string apiURL = $"https://localhost:7109/api/Location/deleteLocation/{Id}";
            var response = await _httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("ShowAllLocation");
            }

            return this.RedirectToAction("ShowAllLocation");

        }
    }
}
