using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication.ExtendedProtection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public IAllRepositories<Bills> _irepos;
        AppDbContext DbContext;

        public BillController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<Bills> repos = new AllRepositories1<Bills>(DbContext, DbContext.Bills);
            _irepos = repos;

        }
        // GET: api/<BillController>
        [HttpGet]
        public IEnumerable<Bills> GetAllBill()
        {
            return _irepos.GetAll();
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BillController>
        [HttpPost]
        public bool CreateBill(Guid IdUser, string Note, int status, Guid IdCoupon, Guid IdShipMethod, Guid IdLocation, Guid IdPaymentMethod)
        {
            Bills bill = new Bills();
            bill.IdUser = IdUser;
            bill.CreateDate = DateTime.Now;
            bill.Note = Note;
            bill.Status = status;
            bill.IdCoupon = IdCoupon;
            bill.IdShipAdressMethod = IdShipMethod;
            bill.IdLocation = IdLocation;
            bill.IdPaymentMethod = IdPaymentMethod;
            return _irepos.Create(bill);
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public bool UpdateBill(Guid id, Bills bill)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            obj.IdUser = bill.IdUser;
            obj.Note = bill.Note;
            obj.Status = bill.Status;
            obj.IdCoupon = bill.IdCoupon;
            obj.IdShipAdressMethod= bill.IdShipAdressMethod;
            obj.IdLocation = bill.IdLocation;
            obj.IdPaymentMethod = bill.IdPaymentMethod;
            return _irepos.Update(obj);
        }

        // DELETE api/<BillController>/5
        [HttpDelete("Delete/{id}")]
        public bool Delete(Guid id)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(obj);
        }
    }
}
