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
    public class AchivePointsController : ControllerBase
    {
        private IAllRepositories<AchivePoint> _achivepointIrepos;
        private readonly AppDbContext _context = new();
        public AchivePointsController()
        {
            var _achivepoint = new AllRepositories1<AchivePoint>(_context, _context.AchivePoints);
        }
        [HttpGet("get-all-achivepoint")]
        public IEnumerable<AchivePoint> GetAllUser()
        {
            return _achivepointIrepos.GetAll();
        }

        [HttpGet("{id}")]
        public AchivePoint GetItem(Guid id)
        {
            return _achivepointIrepos.GetItem(id);
        }
        [HttpPost("create-achivepoint")]
        public bool Createachivepoint(Guid IdUser, int PointValue)
        {
            AchivePoint achivePoint = new AchivePoint();
            achivePoint.Id = Guid.NewGuid();
            achivePoint.IdUser = IdUser;
            achivePoint.PointValue = PointValue;
            return _achivepointIrepos.Create(achivePoint);
        }
        [HttpDelete("delete-achivepoint")]
        public bool Deleteachivepoint(Guid Id)
        {
            var delete = _achivepointIrepos.GetAll().FirstOrDefault(x => x.Id == Id);
            return _achivepointIrepos.Delete(delete);
        }
        [HttpPut("update-achivepoint")]
        public bool UpdateAchivePoint(Guid Id, Guid IdUser, int PointValue)
        {
            var update = _achivepointIrepos.GetAll().FirstOrDefault(x => x.Id == Id);
            update.IdUser = IdUser;
            update.PointValue = PointValue;
            return _achivepointIrepos.Update(update);
        }
    }
}
