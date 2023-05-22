using Data.IRepositories;
using Data.Repositories;
using Data.Models;
using Data.ShopContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public IAllRepositories<Location> _irepos;
        AppDbContext DbContext;

        public LocationController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<Location> repos = new AllRepositories1<Location>(DbContext, DbContext.Location);
            _irepos = repos;
            
        }
        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<Location> GetAllLocation()
        {
            return  _irepos.GetAll();
        }

        // POST api/<LocationController>
        [HttpPost]
        public bool CreateLocation(string stage, string District, string ward, string street, string Address)
        {
            // string stage, string District, string ward, string street, string Address
            Location lc = new Location();
            lc.Stage = stage;
            lc.District = District;
            lc.Ward = ward;
            lc.Street = street;
            lc.Address = Address;
            return  _irepos.Create(lc);

            //return await _irepos.Create(location);
        }

        [HttpDelete("deleteLocation/{id}")]
        public bool DeleteLocation(Guid id)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(obj);
        }


        [HttpPut("updateLocation")]
        public bool UpdateLocation(Location location)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == location.Id);
            obj.Stage = location.Stage;
            obj.District = location.District;
            obj.Ward = location.Ward;
            obj.Street = location.Street;
            obj.Address = location.Address;

            return _irepos.Update(obj);
        }

        
    }
}
