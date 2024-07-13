using CVManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CvManager.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace CVManager.Controllers.Account
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCreateController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountCreateController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _accountService.CreateUserAsync(user);

            if (result)
            {
                return Ok("User created successfully.");
            }

            // var SendEmail = new MailersendUtils();

            // SendEmail.EnviarCorreo("lauravelasquez@gmail.com");

            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
}