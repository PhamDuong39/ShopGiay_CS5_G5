using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using ProjectViews.Areas.User.Models;
using System.Net.Http;

namespace ProjectViews.Areas.User.Controllers
{
  [Area("User")]
  public class ShopController : Controller
  {
    private readonly HttpClient _httpClient;

    public ShopController()
    {
      _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index()
    {
      string apiURL = $"https://localhost:7109/api/BillDetails";
      var response = await _httpClient.GetAsync(apiURL);
      string apiData = await response.Content.ReadAsStringAsync();
      var billDetails = JsonConvert.DeserializeObject<List<BillDetails>>(apiData);
      var lstIdShoeInBillDetail = billDetails.Select(p => p.IdShoeDetail);
      string apiUrls = $"https://localhost:7109/api/ShoeDetails/get-all-shoeDetails";
      var responses = await _httpClient.GetAsync(apiUrls); // goi api lay data
      string apiDatas = await responses.Content.ReadAsStringAsync(); // doc data tra ve
      var shoeDetails = JsonConvert.DeserializeObject<List<ShoeDetails>>(apiDatas);
      string apiURLss = $"https://localhost:7109/api/Sales/Show-Sales";
      var responsess = await _httpClient.GetAsync(apiURLss);
      var apiDatass = await responsess.Content.ReadAsStringAsync();
      var sales = JsonConvert.DeserializeObject<List<Sales>>(apiData);
      HomeUserViewModel homeVMD = new HomeUserViewModel();
      //Group shoe by name and add to list
      var lstShoeGroupName = new List<ShoeDetails>();
      var shoesGroupByName = shoeDetails.OrderBy(p => p.Name).ToList();
      foreach (var item in shoesGroupByName)
      {
        if (!lstShoeGroupName.Any(p => p.Name == item.Name))
        {
          lstShoeGroupName.Add(item);
        }
      }
      return View(lstShoeGroupName);
    }
  }
}
