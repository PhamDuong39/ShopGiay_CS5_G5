using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;
using Microsoft.AspNetCore.Mvc;

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        public IAllRepositories<Sales> _irepos;
        AppDbContext DbContext;

        public SalesController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<Sales> repos = new AllRepositories1<Sales>(DbContext, DbContext.Sales);
            _irepos = repos;

        }
        // GET: api/<BillController>
        [HttpGet("Show-Sales")]
        public IEnumerable<Sales> GetAllSales()
        {
            return _irepos.GetAll();
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Sales Get(Guid id)
        {
            return _irepos.GetAll().First(p => p.Id == id);
        }
        // POST api/<BillController>
        [HttpPost("Create-Sales")]
        public bool CreateSales(int DiscountValue, string SaleName)
        {
            Sales sale = new Sales();
            sale.DiscountValue = DiscountValue;
            sale.SaleName = SaleName;
            sale.StartDate = DateTime.Now;
            sale.EndDate = DateTime.Now.AddDays(7);

            return _irepos.Create(sale);
        }

        // PUT api/<BillController>/5
        [HttpPut("edit-Sales-{id}")]
        public bool UpdateSales(Guid id, int DiscountValue, string SaleName, DateTime StartDate, DateTime EndDate)
        {
            Sales sale = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            sale.DiscountValue = DiscountValue;
            sale.SaleName = SaleName;
            sale.StartDate = StartDate;
            sale.EndDate = EndDate;
            return _irepos.Update(sale);
        }

        // DELETE api/<BillController>/5
        [HttpDelete("Delete-Sales-/{id}")]
        public bool Delete(Guid id)
        {
            Sales sale = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(sale);
        }
    }
}
