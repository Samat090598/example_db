using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AddUser(User user)
        {
            _db.Entry(user).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return new JsonResult(true);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            _db.Entry(user).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return new JsonResult(true);
        }
        
        [HttpPut]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return new JsonResult(true);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(f => f.Id == id);
            return new JsonResult(user);
        } 
    }
}