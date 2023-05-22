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
    public class PaymentMethodController : ControllerBase
    {

        public IAllRepositories<PaymentMethods> _irepos;
        AppDbContext DbContext;

        public PaymentMethodController()
        {
            DbContext = new AppDbContext();
            AllRepositories1<PaymentMethods> repos = new AllRepositories1<PaymentMethods>(DbContext, DbContext.PaymentMethods);
            _irepos = repos;

        }
        // GET: api/<PaymentMethodController>
        [HttpGet]
        public IEnumerable<PaymentMethods> GetAllPaymentMethod()
        {
            return _irepos.GetAll();
        }

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public bool CreatePaymentMethod(int status, string Name)
        {
            PaymentMethods payment = new PaymentMethods();
            payment.NameMethod = Name;
            payment.Status = status;
            return _irepos.Create(payment);
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool UpdatePaymentMethod(Guid id, PaymentMethods paymentMethods)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            obj.NameMethod = paymentMethods.NameMethod;
            obj.Status = paymentMethods.Status;
            return _irepos.Update(obj);
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("Delete/{id}")]
        public bool Delete(Guid id)
        {
            var obj = _irepos.GetAll().FirstOrDefault(p => p.Id == id);
            return _irepos.Delete(obj);
        }
    }
}
