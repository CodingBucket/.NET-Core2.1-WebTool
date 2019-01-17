using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTool.Core.Interfaces;
using WebTool.Core.Services.Interfaces;
using WebTool.Core.ViewModels;

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
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            return await _userDataService.GetUserList();
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
