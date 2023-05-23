

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API_Core.Controllers;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    public IAllRepositories<PaymentMethods> _irepos;

    private readonly AppDbContext DbContext;

    public PaymentMethodController()
    {
        this.DbContext = new AppDbContext();
        var repos = new AllRepositories1<PaymentMethods>(this.DbContext, this.DbContext.PaymentMethods);
        this._irepos = repos;
    }

    // POST api/<PaymentMethodController>
    [HttpPost]
    public bool CreatePaymentMethod(int status, string Name)
    {
        var payment = new PaymentMethods();
        payment.NameMethod = Name;
        payment.Status = status;
        return this._irepos.Create(payment);
    }

    // DELETE api/<PaymentMethodController>/5
    [HttpDelete("Delete/{id}")]
    public bool Delete(Guid id)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        return this._irepos.Delete(obj);
    }

    // GET api/<PaymentMethodController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // GET: api/<PaymentMethodController>
    [HttpGet]
    public IEnumerable<PaymentMethods> GetAllPaymentMethod()
    {
        return this._irepos.GetAll();
    }

    // PUT api/<PaymentMethodController>/5
    [HttpPut("{id}")]
    public bool UpdatePaymentMethod(Guid id, PaymentMethods paymentMethods)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        obj.NameMethod = paymentMethods.NameMethod;
        obj.Status = paymentMethods.Status;
        return this._irepos.Update(obj);
    }
}