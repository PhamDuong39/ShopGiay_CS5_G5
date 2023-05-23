using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipMethodController : ControllerBase
    {
        public IAllRepositories<ShipAdressMethod> _irepos;
        AppDbContext DbContext;

        public ShipMethodController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<ShipAdressMethod> repos = new AllRepositories1<ShipAdressMethod>(DbContext, DbContext.ShipAdressMethods);
            _irepos = repos;

        }

        // GET: api/<ShipMethodController>
        [HttpGet]
        public IEnumerable<ShipAdressMethod> GetAllShipMethod()
        {
            return _irepos.GetAll();
        }

        // GET api/<ShipMethodController>/5
        [HttpGet("{id}")]
        public ShipAdressMethod Getone(Guid id)
        {
            return _irepos.GetAll().FirstOrDefault(p => p.Id == id);
        }

        // POST api/<ShipMethodController>
        [HttpPost]
        public bool CreateShipMethod(string Name, int status, int price)
        {
            ShipAdressMethod shipMethod = new ShipAdressMethod();
            shipMethod.NameAddress = Name;
            shipMethod.Status = status;
            shipMethod.Price = price;

            return _irepos.Create(shipMethod);
        }

        // PUT api/<ShipMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string Name, int status, int price)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            obj.NameAddress = Name;
            obj.Status = status;
            obj.Price = price;

            return _irepos.Update(obj);
        }

        // DELETE api/<ShipMethodController>/5
        [HttpDelete("DeleteShipMethod/{id}")]
        public bool Delete(Guid id)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(obj);
        }
    }
}
