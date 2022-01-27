using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;
using Auction.Business.Contracts.Items;
using Auction.Business.Contracts.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auction.Models;
using Auction.Business.Services.Users;
using Auction.Data.Querying;
using Auction.Extensions;
using Auction.Domain.Models;
using Auction.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Auction.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator _passwordValidator;

        public AccountController(IUserService userService, IMapper mapper, IPasswordValidator passwordValidator)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var credentials =  _mapper.Map<UserHashedCredentials>(await _passwordValidator.ValidatePassword(model.Email, model.Password));
                
                if (credentials.Email != null)
                {
                    var user = await _userService.GetForLogin(credentials);
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            List<int> treads = new List<int>();
            treads.Add(Thread.CurrentThread.ManagedThreadId);
            if (ModelState.IsValid)
            {
                var credentials = _mapper.Map<UserHashedCredentials>(_passwordValidator.HashPassword(model.Email, model.Password));
                var user = await _userService.GetForLogin(credentials);
                treads.Add(Thread.CurrentThread.ManagedThreadId);
                if (user == null)
                {
                    user = await _userService.CreateUser(_mapper.Map<CreateUserCommand>(credentials));
                    treads.Add(Thread.CurrentThread.ManagedThreadId);
                    await Authenticate(user);
                    treads.Add(Thread.CurrentThread.ManagedThreadId);
                    return RedirectToAction("Index", "Home");
                }
                treads.Add(Thread.CurrentThread.ManagedThreadId);
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            treads.Add(Thread.CurrentThread.ManagedThreadId);
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>

            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),

            };

            foreach (Role role in user.Roles) claims.Add(new Claim(ClaimTypes.Role, role.Name));

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimTypes.Role);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
