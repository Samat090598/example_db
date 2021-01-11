using example_db.Models;
using example_db.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace example_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private ApplicationContext _db;

        public UsersController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _db.Entry(user).State = EntityState.Added;
            _db.SaveChanges();
            return new JsonResult(true);
        }
    }
}