using CvManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var users = await _usersService.GetAll();

            if (users.Any())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    users = users.Where(u => u.Name!.Contains(search));
                    return View(users);
                }
                return View(users);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _usersService.GetById(id);
            if (user != null) return View(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Deleted()
        {
            var users = await _usersService.GetAllDeleted();
            if (users.Any()) return View(users);
            return RedirectToAction("Index", "Home");
        }
    }
}