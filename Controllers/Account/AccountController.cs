using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvManager.Data;
using CvManager.Models;
using CvManager.ViewModels;

namespace CvManager.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly BaseContext _baseContext;
        public AccountController(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            return View();
        }
    }
}