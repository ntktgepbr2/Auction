using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auction.Models;
using Auction.Business.Services.Users;
using Auction.Extensions;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Auction.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
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
                var user = await _userService.GetForLogin(model.Email, model.Password);
                    if (user != null)
                    {
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

            if (ModelState.IsValid)
            {
                var user = await _userService.GetForLogin(model.Email, model.Password);
                    if (user == null)
                    {
                        user = await _userService.CreateUser(model.LoginModelToCommand());
                        await Authenticate(user);

                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
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
