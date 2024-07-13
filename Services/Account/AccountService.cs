using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CvManager.Services;
using CvManager.Services.Account;

namespace CvManager.Services.Account
{
    public class AccountService : IAccountService
    {
         private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            user.CreateAt = DateTime.Now;
            user.UpdateAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}