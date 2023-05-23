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
        public bool CreateCartDetail(Guid IdUser,Guid IdShoesDetail,int Quantity)
        {
            CartDetails cartDetails = new CartDetails();
            cartDetails.Quantity = Quantity;
            cartDetails.Id = Guid.NewGuid();
            cartDetails.IdUser = IdUser;
            cartDetails.IdShoeDetail = IdShoesDetail;
            return _irepos.Create(cartDetails);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("update-cartdetail")]
        public bool UpdateCartDetail(Guid id, Guid idShoeDetail, Guid idUser, int quantity)
        {
            CartDetails cartdetail = _irepos.GetAll().First(p => p.Id == id);
            cartdetail.Quantity = quantity;
            cartdetail.IdUser = idUser;
            cartdetail.IdShoeDetail = idShoeDetail;
            return _irepos.Update(cartdetail);
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
