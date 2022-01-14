using System;
using System.Linq;
using System.Threading.Tasks;
using Auction.Business.Services.Roles;
using Auction.Business.Services.Users;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid Id)
        {
            return Ok(new { name = "Daniel" });
        }

        [HttpGet()]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            User user = await _userService.GetUserByEmail(name);

            return View("~/Views/Home/Administration.cshtml", user);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<User>> AddUserRole(Guid Id, string[] roles)
        {
            User user = await _userService.GetUserById(Id);
            Role role = await _roleService.GetRole(roles.FirstOrDefault());
            user.Roles.Add(role);
            //await _userService.UpdateUserContext();

            return View("~/Views/Home/Administration.cshtml", user);
        }

        [HttpGet()]
        public IActionResult GetAllUsers()
        {
            return Ok(new { name = "Daniel" });
        }
    }
}
