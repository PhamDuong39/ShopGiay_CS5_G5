

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API_Core.Controllers;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ShipMethodController : ControllerBase
{
    public IAllRepositories<ShipAdressMethod> _irepos;

    private readonly AppDbContext DbContext;

    public ShipMethodController()
    {
        this.DbContext = new AppDbContext();
        var repos = new AllRepositories1<ShipAdressMethod>(this.DbContext, this.DbContext.ShipAdressMethods);
        this._irepos = repos;
    }

    // POST api/<ShipMethodController>
    [HttpPost]
    public bool CreateShipMethod(string Name, int status, int price)
    {
        var shipMethod = new ShipAdressMethod();
        shipMethod.NameAddress = Name;
        shipMethod.Status = status;
        shipMethod.Price = price;

        return this._irepos.Create(shipMethod);
    }

    // DELETE api/<ShipMethodController>/5
    [HttpDelete("DeleteShipMethod/{id}")]
    public bool Delete(Guid id)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        return this._irepos.Delete(obj);
    }

    // GET api/<ShipMethodController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // GET: api/<ShipMethodController>
    [HttpGet]
    public IEnumerable<ShipAdressMethod> GetAllShipMethod()
    {
        return this._irepos.GetAll();
    }

    // PUT api/<ShipMethodController>/5
    [HttpPut("{id}")]
    public bool Put(Guid id, ShipAdressMethod shipAdressMethod)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        obj.NameAddress = shipAdressMethod.NameAddress;
        obj.Status = shipAdressMethod.Status;
        obj.Price = shipAdressMethod.Price;

        return this._irepos.Update(obj);
    }
}