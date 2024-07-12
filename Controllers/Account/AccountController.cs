using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvManager.Data;
using CvManager.Models;

namespace CvManager.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly BaseContext _baseContext;
        public AccountController(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}