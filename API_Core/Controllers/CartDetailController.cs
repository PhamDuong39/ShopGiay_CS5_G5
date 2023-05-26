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
  public class CartDetailController : ControllerBase
  {
    public IAllRepositories<CartDetails> _irepos;
    AppDbContext DbContext;

    public CartDetailController()
    {
      DbContext = new AppDbContext();
      AllRepositories1<CartDetails> repos = new AllRepositories1<CartDetails>(DbContext, DbContext.CartDetails);
      _irepos = repos;

    }
    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<CartDetails> Get()
    {
      return _irepos.GetAll();
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public CartDetails Get(Guid id)
    {
      return _irepos.GetAll().First(p => p.Id == id);
    }

    // POST api/<ValuesController>
    [HttpPost("create-cartdetail")]
    public string CreateCartDetail(Guid IdUser, Guid IdShoesDetail, int Quantity)
    {
      //check quantity have more than AvailableQuantity
      if (Quantity > _irepos.GetAll().First(p => p.Id == IdShoesDetail).ShoeDetails.AvailableQuantity)
      {
        return "Quantity is not enough";
      }
      CartDetails cartDetails = new CartDetails();
      cartDetails.Quantity = Quantity;
      cartDetails.Id = Guid.NewGuid();
      cartDetails.IdUser = IdUser;
      cartDetails.IdShoeDetail = IdShoesDetail;
      if (_irepos.Create(cartDetails))
      {
        return "Create success !";
      }
      else
      {
        return "Create fail !";
      }
    }

    // PUT api/<ValuesController>/5
    [HttpPut]
    [Route("update-cartdetail")]
    public string UpdateCartDetail(Guid id, Guid idShoeDetail, Guid idUser, int quantity)
    {
      CartDetails cartdetail = _irepos.GetAll().First(p => p.Id == id);
      //check quantity have more than AvailableQuantity
      if (quantity > _irepos.GetAll().First(p => p.Id == id).ShoeDetails.AvailableQuantity)
      {
        return "Quantity is not enough";
      }
      cartdetail.Quantity = quantity;
      cartdetail.IdUser = idUser;
      cartdetail.IdShoeDetail = idShoeDetail;
      if (_irepos.Update(cartdetail))
      {
        return "Update success !";
      }
      else
      {
        return "Update fail !";
      }
    }
    [HttpDelete("delete-many")]
    public string DeleteMany(List<Guid> idCarts)
    {
      var _cartDetailLst = new List<CartDetails>();
      try
      {
        foreach (var item in idCarts)
        {
          CartDetails obj = _irepos.GetAll().First(p => p.Id == item);
          _cartDetailLst.Add(obj);
        }
        if (_irepos.DeleteMany(_cartDetailLst))
        {
          return "Delete many done";
        }
        else
        {
          return "Delete many fail";
        }
      }
      catch (Exception e)
      {
        return e.Message.ToString();
      }
    }
    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public bool Delete(Guid id)
    {
      CartDetails obj = _irepos.GetAll().First(p => p.Id == id);
      return _irepos.Delete(obj);
    }
  }
}
