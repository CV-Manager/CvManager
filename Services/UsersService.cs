using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CvManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly BaseContext _context;

        public UsersService(BaseContext context)
        {
            _context = context;
        }

        public async Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.Where(u => u.Status == "ACTIVE").ToListAsync();
            if (users.Any()) return users;
            return Enumerable.Empty<User>();
        }

        public async Task<IEnumerable<User>> GetAllDeleted()
        {
            var users = await _context.Users.Where(u => u.Status == "INACTIVE").ToListAsync();
            if (users.Any()) return users;
            return Enumerable.Empty<User>();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id == id);
            if (user!= null) return user;
            return null!;
        }

        public async Task<User> Restore(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(int id, UserVM user)
        {
            throw new NotImplementedException();
        }
    }
}