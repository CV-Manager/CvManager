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
        public Task<User> Register(UserVM user)
        {
            User userRegistration = new User (
                user.Country,
                user.Email,
                user.Password,
                
            );
        }
    }
}