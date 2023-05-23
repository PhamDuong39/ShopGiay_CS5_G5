

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API_Core.Controllers;

using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Data.ShopContext;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase
{
    public IAllRepositories<Bills> _irepos;

    private readonly AppDbContext DbContext;

    public BillController()
    {
        this.DbContext = new AppDbContext();
        var repos = new AllRepositories1<Bills>(this.DbContext, this.DbContext.Bills);
        this._irepos = repos;
    }

    // POST api/<BillController>
    [HttpPost]
    public bool CreateBill(
        Guid IdUser,
        string Note,
        int status,
        Guid IdCoupon,
        Guid IdShipMethod,
        Guid IdLocation,
        Guid IdPaymentMethod)
    {
        var bill = new Bills();
        bill.IdUser = IdUser;
        bill.CreateDate = DateTime.Now;
        bill.Note = Note;
        bill.Status = status;
        bill.IdCoupon = IdCoupon;
        bill.IdShipAdressMethod = IdShipMethod;
        bill.IdLocation = IdLocation;
        bill.IdPaymentMethod = IdPaymentMethod;
        return this._irepos.Create(bill);
    }

    // DELETE api/<BillController>/5
    [HttpDelete("Delete/{id}")]
    public bool Delete(Guid id)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        return this._irepos.Delete(obj);
    }

    // GET api/<BillController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // GET: api/<BillController>
    [HttpGet]
    public IEnumerable<Bills> GetAllBill()
    {
        return this._irepos.GetAll();
    }

    // PUT api/<BillController>/5
    [HttpPut("{id}")]
    public bool UpdateBill(Guid id, Bills bill)
    {
        var obj = this._irepos.GetAll().FirstOrDefault(p => p.Id == id);
        obj.IdUser = bill.IdUser;
        obj.Note = bill.Note;
        obj.Status = bill.Status;
        obj.IdCoupon = bill.IdCoupon;
        obj.IdShipAdressMethod = bill.IdShipAdressMethod;
        obj.IdLocation = bill.IdLocation;
        obj.IdPaymentMethod = bill.IdPaymentMethod;
        return this._irepos.Update(obj);
    }
}