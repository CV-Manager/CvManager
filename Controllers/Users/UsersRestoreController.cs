using CvManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.Users
{
    public class UsersRestoreController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersRestoreController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            _usersService.Restore(id);
            return RedirectToAction("Index", "Users");
        }        
    }
}