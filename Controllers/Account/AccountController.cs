using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvManager.Data;
using CvManager.Models;
using CvManager.ViewModels;
using CvManager.Interfaces;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM userVM)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var user = await _accountService.Register(userVM);

            if(user.Id != 0){
                return RedirectToAction("Login", "Account");
            }

            ViewData["Message"] = "No se pudo registrar el usuario, error.";
            return View();
        }
    }
}