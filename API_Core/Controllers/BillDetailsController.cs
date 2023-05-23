

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API_Core.Controllers;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BillDetailsController : ControllerBase
{
    public IAllRepositories<BillDetails> _irepos;

    private readonly AppDbContext DbContext;

    public BillDetailsController()
    {
        this.DbContext = new AppDbContext();
        var repos = new AllRepositories1<BillDetails>(this.DbContext, this.DbContext.BillDetails);
        this._irepos = repos;
    }

    //// PUT api/<BillDetailsController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<BillDetailsController>/5
    [HttpDelete("{id}")]
    public bool Delete(Guid id)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        return this._irepos.Delete(obj);
    }

    // GET: api/<BillDetailsController>
    [HttpGet]
    public IEnumerable<BillDetails> GetAllBillDetails()
    {
        return this._irepos.GetAll();
    }

    //// GET api/<BillDetailsController>/5
    // [HttpGet("{id}")]
    // public string Get(int id)
    // {
    // return "value";
    // }

    // POST api/<BillDetailsController>
    [HttpPost]
    public bool Post(Guid IdShoeDetail, Guid IdBill, int price, int quantity)
    {
        var bd = new BillDetails();
        bd.IdShoeDetail = IdShoeDetail;
        bd.IdBill = IdBill;
        bd.Price = price;
        bd.Quantity = quantity;
        return this._irepos.Create(bd);
    }
}