using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTool.Core.Interfaces;
using WebTool.Core.Services.Interfaces;

namespace WebTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserDataService _userDataService;

        public UsersController(IUserService userService, IUserDataService userDataService)
        {
            _userService = userService;
            _userDataService = userDataService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var userList = await _userDataService.GetUserListAsync();
            if (userList == null)
            {
                return NotFound();
            }
            return Ok(userList);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(long id)
        {
            var user = await _userDataService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
