using CvManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.Users
{
    public class UsersDeleteController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersDeleteController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _usersService.Delete(id);
            return RedirectToAction("Index", "Users");
        }        
    }
}