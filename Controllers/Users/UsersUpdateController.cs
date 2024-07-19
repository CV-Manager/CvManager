using CvManager.Interfaces;
using CvManager.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.Users
{
    public class UsersUpdateController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersUpdateController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _usersService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = _mapper.Map<UserVM>(user);
            return View(userVM);           
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(int id, [FromBody] UserVM userVM)
        {
            if (!ModelState.IsValid) return View("Edit", userVM);
            
            try
            {
                var user = await _usersService.Update(id, userVM);
                if (user == null) return NotFound();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Edit", userVM);
            }           
        }
    }
}