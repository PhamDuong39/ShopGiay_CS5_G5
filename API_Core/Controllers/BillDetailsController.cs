using Data.IRepositories;
using Data.Repositories;

using Data.Models;
using Data.ShopContext;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        public IAllRepositories<BillDetails> _irepos;
        AppDbContext DbContext;

        public BillDetailsController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<BillDetails> repos = new AllRepositories1<BillDetails>(DbContext, DbContext.BillDetails);
            _irepos = repos;

        }

        // GET: api/<BillDetailsController>
        [HttpGet]
        public IEnumerable<BillDetails> GetAllBillDetails()
        {
            return _irepos.GetAll();
        }

        // GET api/<BillDetailsController>/5
        [HttpGet("{id}")]
        public BillDetails Getone(Guid id)
        {
            return _irepos.GetAll().FirstOrDefault(p => p.Id  == id);
        }

        //POST api/<BillDetailsController>
        [HttpPost]
        public bool Post(Guid IdShoeDetail, Guid IdBill, int price, int quantity)
        {
            BillDetails bd = new BillDetails();
            bd.IdShoeDetail = IdShoeDetail;
            bd.IdBill = IdBill;
            bd.Price = price;
            bd.Quantity = quantity;
            return _irepos.Create(bd);
        }

        // PUT api/<BillDetailsController>/5
        [HttpPut("{id}")]
        public bool UpdateBilldetails(Guid id, Guid IdShoeDetail, Guid IdBill, int price, int quantity)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            obj.IdShoeDetail = IdShoeDetail;
            obj.IdBill = IdBill;
            obj.Price = price;
            obj.Quantity = quantity;
            return _irepos.Update(obj);
        }

        // DELETE api/<BillDetailsController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(obj);
        }
    }
}
