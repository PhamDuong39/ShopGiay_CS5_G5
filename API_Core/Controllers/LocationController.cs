

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API_Core.Controllers;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    public IAllRepositories<Location> _irepos;

    private readonly AppDbContext DbContext;

    public LocationController()
    {
        this.DbContext = new AppDbContext();
        var repos = new AllRepositories1<Location>(this.DbContext, this.DbContext.Location);
        this._irepos = repos;
    }

    // POST api/<LocationController>
    [HttpPost]
    public bool CreateLocation(string stage, string District, string ward, string street, string Address)
    {
        // string stage, string District, string ward, string street, string Address
        var lc = new Location();
        lc.Stage = stage;
        lc.District = District;
        lc.Ward = ward;
        lc.Street = street;
        lc.Address = Address;
        return this._irepos.Create(lc);

        // return await _irepos.Create(location);
    }

    [HttpDelete("deleteLocation/{id}")]
    public bool DeleteLocation(Guid id)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        return this._irepos.Delete(obj);
    }

    // GET: api/<LocationController>
    [HttpGet]
    public IEnumerable<Location> GetAllLocation()
    {
        return this._irepos.GetAll();
    }

    [HttpPut("updateLocation")]
    public bool UpdateLocation(Location location)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == location.Id);
        obj.Stage = location.Stage;
        obj.District = location.District;
        obj.Ward = location.Ward;
        obj.Street = location.Street;
        obj.Address = location.Address;

        return this._irepos.Update(obj);
    }
}