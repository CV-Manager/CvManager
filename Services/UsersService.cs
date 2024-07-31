using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CvManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public UsersService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;            
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user!= null)
            {
                if (user.Status == "INACTIVE")
                {
                    throw new Exception("El usuario ya esta inactivo.");
                }
                else
                {
                    user.Status = "INACTIVE";
                    user.UpdateAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
            throw new Exception("El usuario no existe.");
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
            var user = await GetById(id);
            if (user!= null)
            {
                if (user.Status == "ACTIVE")
                {
                    throw new Exception("El usuario ya esta activo.");
                }
                else
                {
                    user.Status = "ACTIVE";
                    user.UpdateAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return user;
                }
            }
            throw new Exception("El usuario no existe.");
        }

        public async Task Update(int id, UserVM userUpdate)
        {
            var user = await GetById(id);
            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }
            _mapper.Map(userUpdate, user);
            user.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}