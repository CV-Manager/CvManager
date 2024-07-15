using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvManager.Models;
using CvManager.ViewModels;
using CvManager.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace CvManager.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if(User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if(!ModelState.IsValid){
                ViewData["Message"] = "Error en los campos.";
                return View();
            }

            var user = await _accountService.Register(userVM);

            if(user.Id != 0){
                return RedirectToAction("Login", "Account");
            }

            ViewData["Message"] = "No se pudo registrar el usuario, error fatal.";
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if(!ModelState.IsValid){
                 ViewData["Message"] = "Error en los campos.";
                return View();
            }

            var user = await _accountService.Login(userVM);

            if(user == null){
                ViewData["Message"] = "No se encontraron coincidencias.";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email!)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }
    }
}