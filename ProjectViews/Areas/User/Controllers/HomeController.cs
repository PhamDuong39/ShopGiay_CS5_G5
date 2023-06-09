
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using ProjectViews.Areas.User.Models;
using System.Net.Http;

namespace ProjectViews.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            // Get all bill
            string apiURL = $"https://localhost:7109/api/BillDetails";
            var response = await _httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var billDetails = JsonConvert.DeserializeObject<List<BillDetails>>(apiData);
            var lstIdShoeInBillDetail = billDetails.Select(p => p.IdShoeDetail);

            // Get all ShoeDetails
            string apiUrls = $"https://localhost:7109/api/ShoeDetails/get-all-shoeDetails";
            var responses = await _httpClient.GetAsync(apiUrls); // goi api lay data
            string apiDatas = await responses.Content.ReadAsStringAsync(); // doc data tra ve
            var shoeDetails = JsonConvert.DeserializeObject<List<ShoeDetails>>(apiDatas);

            // Get all Sale Event
            string apiURLss = $"https://localhost:7109/api/Sales/Show-Sales";
            var responsess = await _httpClient.GetAsync(apiURLss);
            var apiDatass = await responsess.Content.ReadAsStringAsync();
            var sales = JsonConvert.DeserializeObject<List<Sales>>(apiData);

            HomeUserViewModel homeVMD = new HomeUserViewModel();

            // Get the top 4 shoe in the BillDetail - TOP PRODUCT IN SHOP
            #region HOT Product
            List<ShoeDetails> lstTopShoe = new List<ShoeDetails>();
            if (billDetails.Count >= 4 && shoeDetails.Count >= 4)
            {
                var TopBillQuantity = billDetails.OrderByDescending(p => p.Quantity).Take(4).ToList();

                foreach (var item in shoeDetails)
                {
                    foreach (var bill in TopBillQuantity)
                    {
                        if (item.Id == bill.IdShoeDetail)
                        {
                            lstTopShoe.Add(item);
                        }
                    }
                }
            }
            else if(billDetails.Count < 4 && shoeDetails.Count >= 4)
            {
                // Lấy toàn bộ sản phẩm có trong billDetail (<4)
                var TopBillQuantity = billDetails.OrderByDescending(p => p.Quantity).ToList();
                foreach (var item in shoeDetails)
                {
                    foreach (var bill in TopBillQuantity)
                    {
                        if (item.Id == bill.IdShoeDetail)
                        {
                            lstTopShoe.Add(item);
                        }
                    }
                }

                // Tổng hiển thị là 4sp => lấy số sản phẩm còn lại bằng cách sử dụng for loop. CHọn random các sp còn lại. Đủ 4 là dừng
                int numberOfLoop = 4 - TopBillQuantity.Count;
                Random r = new Random();
                for (int i = 0; i < numberOfLoop; i++)
                {
                    int randomIndex = r.Next(shoeDetails.Count);
                    ShoeDetails shoeRandomSelected = shoeDetails[randomIndex];
                    if (billDetails.Exists(p => p.IdShoeDetail == shoeRandomSelected.Id) && !lstTopShoe.Contains(shoeRandomSelected))
                    {
                        lstTopShoe.Add(shoeRandomSelected);
                    }
                }
            }
            else if (billDetails.Count < 4 && shoeDetails.Count < 4)
            {
                foreach (var item in shoeDetails)
                {
                    lstTopShoe.Add(item);
                }
            }

            homeVMD.bestSellers = lstTopShoe;

            #endregion

            // Get the top 4 newest shoe in the shoeDEtail - NEW ARRIVALS IN SHOP
            #region New Arrivals

            List<ShoeDetails> lstNewArrival = new List<ShoeDetails>();
            if (shoeDetails.Count <= 4)
            {
                foreach (var item in shoeDetails)
                {
                    lstNewArrival.Add(item);
                }
            }
            else
            {
                for (int i = shoeDetails.Count - 4; i < shoeDetails.Count; i++)
                {
                    ShoeDetails shoe = shoeDetails[i];
                    lstNewArrival.Add(shoe);
                }
            }
            homeVMD.newArrivals = lstNewArrival;

            // Cho nay nhe
            List<ShoeHomePageViewModel> lstShoeVMD = new List<ShoeHomePageViewModel>();
            var groupList = lstNewArrival.GroupBy(p => p.Name).Select(p => p.First()).ToList();
            foreach (var item in groupList)
            {
				ShoeHomePageViewModel shoeVMD = new ShoeHomePageViewModel();
                shoeVMD.Name = item.Name;
                shoeVMD.Price = item.SellPrice;
                lstShoeVMD.Add(shoeVMD);
			}

		    homeVMD.shoeHomePageViewModels = lstShoeVMD;

			#endregion

			#region BestDiscount

			List<ShoeDetails> bestDiscountsList = new List<ShoeDetails>();
            var topValueSale = sales.OrderByDescending(p => p.DiscountValue).Take(2).ToList();
            foreach (var item in shoeDetails)
            {
                foreach (var sale in topValueSale)
                {
                    if (item.IdSale == sale.Id)
                    {
						bestDiscountsList.Add(item);

					}
                }
            }
            homeVMD.bestDiscounts = bestDiscountsList;
            #endregion

            return View(homeVMD);
        }
    }
}
