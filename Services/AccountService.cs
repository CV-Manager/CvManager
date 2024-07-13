using Microsoft.EntityFrameworkCore;
using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Services
{
    public class AccountService : IAccountService
    {
        private readonly BaseContext _context;
        public AccountService(BaseContext context)
        {          
            _context = context;
        }

        public async Task<User> Login(LoginVM user)
        {
            User? userFind = await _context.Users
            .Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
            if (userFind != null)
            {
                return userFind;
            }
            return null!;
        }

        public async Task<User> Register(RegisterVM user)
        {
            User userRegistration = new User() {
                Country = user.Country,
                Email = user.Email,
                Password = user.Password
            };              
            
            await _context.Users.AddAsync(userRegistration);
            await _context.SaveChangesAsync();          
            return userRegistration;
        }
    }
}