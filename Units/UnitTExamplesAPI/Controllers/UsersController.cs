using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitTExamplesAPI.Data;
using UnitTExamplesAPI.Models;

namespace UnitTExamplesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UnitTExamplesContext uNITTExamplesContext;


        public UsersController(UnitTExamplesContext _uNITTExamplesContext)
        {
            uNITTExamplesContext = _uNITTExamplesContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.User>>> GetUsers()
        {
            return await uNITTExamplesContext.Users.ToListAsync();
        }

        [HttpGet("{_uSerN}")]
        public async Task<ActionResult> GetUser(string _uSerN)
        {
            var uSer = await uNITTExamplesContext.
                Users.FirstOrDefaultAsync(N => N.Vorname == _uSerN);

            if (uSer == null)
            {
                return NotFound();
            }

            return Ok(uSer);
        }

        [HttpPut("{_uSerN}")]
        public async Task<ActionResult> UpdateUser(string _uSerN, Models.User _uSer)
        {
            if (_uSerN != _uSer.Vorname)
            {
                return BadRequest();
            }

            uNITTExamplesContext.Entry(_uSer).State = EntityState.Modified;
            await uNITTExamplesContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{_uSerN}")]
        public async Task<ActionResult> DeleteUser(string _uSerN)
        {
            var uSer = await uNITTExamplesContext.Users.
                FirstOrDefaultAsync(n => n.Vorname == _uSerN);

            if (uSer == null)
                return NotFound();

            uNITTExamplesContext.Users.Remove(uSer);
            await uNITTExamplesContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
