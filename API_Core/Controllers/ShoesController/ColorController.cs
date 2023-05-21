namespace API_Core.Controllers.ShoesController;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ColorController : Controller
{
    private IAllRepositories<Colors> _colorIrepos;

    private readonly AppDbContext _context = new();

    public ColorController()
    {
        var _colorRepos = new AllRepositories<Colors>(this._context, this._context.Colors);
        this._colorIrepos = _colorRepos;
    }

    [HttpPost("create-color")]
    public bool CreateColor(string colorName)
    {
        var color = new Colors();
        color.Id = Guid.NewGuid();
        color.ColorName = colorName;

        // check trung ten mau   
        if (this._colorIrepos.GetAll().Select(p => p.ColorName == colorName).Count() == 1)
        {
            Console.WriteLine("Color name is existed");
        }
        else if (string.IsNullOrEmpty(colorName))
        {
            Console.WriteLine("Color name is null or empty");
        }
        else
        {
            Console.WriteLine("Create Done!");
            return this._colorIrepos.CreateItem(color); // tạo màu mới
        }

        return false;
    }

    [HttpPost("create-many-colors")]
    public bool CreateManyColors(List<string> colorNames)
    {
        try
        {
            var colors = new List<Colors>();
            foreach (var name in colorNames)
            {
                var color = new Colors { Id = Guid.NewGuid(), ColorName = name };

                colors.Add(color);
            }

            return this._colorIrepos.CreateMany(colors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("delete-color-by-id")]
    public bool DeleteColor(Guid Id)
    {
        var colorDelete = this._colorIrepos.GetAll().FirstOrDefault(i => i.Id == Id); // lấy màu có id tương ứng
        return this._colorIrepos.DeleteItem(colorDelete); // xóa màu
    }

    [HttpDelete("delete-many-colors")]
    public bool DeleteManyColors(List<Guid> Id)
    {
        // lay danh sach mau co id trung voi id truyen vao
        List<Colors> colors = this._colorIrepos.GetAll().Where(p => Id.Contains(p.Id)).ToList();
        return this._colorIrepos.DeleteMany(colors);
    }

    // GET : api/Colors
    [HttpGet("get-all-colors")]
    public IEnumerable<Colors> GetAllColors()
    {
        return this._colorIrepos.GetAll(); // trả về danh sách tất cả các màu
    }

    [HttpGet("get-color-by-id/{id}")]
    public Colors GetColorById(Guid id)
    {
        return this._colorIrepos.GetItem(id); // trả về màu có id tương ứng
    }

    [HttpGet("get-color-by-name/{name}")]
    public List<Colors> GetColorByName(string name)
    {
        return this._colorIrepos.GetAll().Where(p => p.ColorName == name).ToList();
    }

    [HttpPut("update-color-by-id")]
    public bool UpdateColor(Guid Id, string colorName)
    {
        // frombody: lay du lieu tu body cua request
        if (Id == null || this._colorIrepos.GetAll().Select(p => p.Id == Id).Count() != 1)
            Console.WriteLine("Color id is null or empty");
        var colorUpdate = this._colorIrepos.GetAll().FirstOrDefault(i => i.Id == Id); // lấy màu có id tương ứng
        colorUpdate.ColorName = colorName; // cập nhật tên màu
        return this._colorIrepos.UpdateItem(colorUpdate); // cập nhật màu
    }

    // Dung update all cung duoc nhung phai truyen du lieu day du len
    // Han Che dung update all vi phai truyen du lieu day du len
    //[HttpPut("update-many-colors")]
    //public bool UpdateManyColors(List<Guid> Id, List<string> colorName)
    //{
    //    try
    //    {
    //        var colors = new List<Colors>();

    //        for (var i = 0; i < Id.Count; i++)
    //        {
    //            var color = new Colors { Id = Id[i], ColorName = colorName[i] };

    //            colors.Add(color);
    //        }

    //        return this._colorIrepos.UpdateMany(colors);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e.Message); // nen dung try catch de bao loi
    //        return false;
    //    }
    //}
}