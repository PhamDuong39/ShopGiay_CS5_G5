using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ProjectViews.Areas.User.Controllers
{
  [Area("User")]
  public class CategoryController : Controller
  {
    private readonly HttpClient _httpClient;
    public CategoryController()
    {
      _httpClient = new HttpClient();
    }
    public async Task<IActionResult> Category()
    {
      string apiShoes = $"https://localhost:7109/api/ShoeDetails/get-all-shoeDetails";
      var responseShoes = await _httpClient.GetAsync(apiShoes);
      string apiDataShoes = await responseShoes.Content.ReadAsStringAsync();
      var shoeDetails = JsonConvert.DeserializeObject<List<ShoeDetails>>(apiDataShoes);
      // add shoeDetails to viewbag
      ViewBag.shoeDetails = shoeDetails;
      return View();
    }
  }
}
