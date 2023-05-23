using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ProjectViews.Controllers
{
    public class LocationController  :Controller
    {
        public LocationController()
        {
            
        }

        public async Task<IActionResult> ShowAllLocation()
        {
            // Call API
            string apiUrl = $"https://localhost:7109/api/Location";
            var HttpClient = new HttpClient();
            var response = await HttpClient.GetAsync(apiUrl);
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
    }
}
