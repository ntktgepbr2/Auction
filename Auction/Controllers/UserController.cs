using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Auction.Business.Services.Logging;
using Auction.Business.Services.Roles;
using Auction.Business.Services.Users;
using Auction.Contracts.Roles;
using Auction.Contracts.Users;
using Auction.Domain.Models;
using Auction.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Extensions;

namespace Auction.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<UserDto>> GetUserForAdminPage(GetUserRequest request)
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.GetUserByEmail(request.Name);
                return View("~/Views/Home/Administration.cshtml", _mapper.Map<UserDto>(user));
            }

            return View("~/Views/Home/Administration.cshtml");
        }

        [HttpGet()]
        public async Task<ActionResult<UserDto>> GetUserByName(GetUserRequest request)
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.GetUserByEmail(request.Name);
                return View(_mapper.Map<UserDto>(user));
            }

            return View("~/Views/Home/Administration.cshtml");
        }

        [HttpPost()]
        public async Task<ActionResult<UserDto>> AddUserRole(AddUserRoleRequest request)
        {
            User user = await _userService.GetUserByEmail(request.Name);
            Role role = await _roleService.GetRole(request.Roles.FirstOrDefault());
            //Task.WaitAll();
            if (user.Roles.Contains(role))
            {
                ViewBag.ErrorMessage = $"This user is already have {role.Name} role";
                return View("~/Views/Home/Administration.cshtml",_mapper.Map<UserDto>(user));
            }
            user.Roles.Add(role);
            await _roleService.UpdateUserContext();

            return View("~/Views/Home/Administration.cshtml", _mapper.Map<UserDto>(user));

        }

        [HttpPost()]
        public async Task<ActionResult<UserDto>> RemoveUserRole(RemoveUserRoleRequest request)
        {
            User user = await _userService.GetUserByEmail(request.Name);
            Role role = await _roleService.GetRole(request.Roles.FirstOrDefault());
            //Task.WaitAll();
            if (!user.Roles.Contains(role))
            {
                ViewBag.ErrorMessage = $"User doesn't have {role.Name} role";
                return View("~/Views/Home/Administration.cshtml", _mapper.Map<UserDto>(user));
            }
            user.Roles.Remove(role);
            await _roleService.UpdateUserContext();

            return View("~/Views/Home/Administration.cshtml", _mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await _userService.DeleteUser(id);

            return RedirectToAction("Administration", "Home");
        }
    }
}
