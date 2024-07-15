using Microsoft.EntityFrameworkCore;
using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using System.Threading.Tasks;
using CvManager.ViewModels;

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
            // Busca el usuario por correo electrónico
            User? userFind = await _context.Users
                .Where(u => u.Email == user.Email)
                .FirstOrDefaultAsync();

            // Verifica la contraseña del usuario
            if (userFind != null && BCrypt.Net.BCrypt.Verify(user.Password, userFind.Password))
            {
                return userFind;
            }
            return null!;
        }

        public async Task<User> Register(RegisterVM user)
        {
            // Verifica si el correo electrónico ya está en uso
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                throw new Exception("Email already in use.");
            }

            // Crea un nuevo usuario
            User userRegistration = new User
            {
                Country = user.Country,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Status = "ACTIVE"
            };

            // Agrega el nuevo usuario a la base de datos y guarda los cambios
            await _context.Users.AddAsync(userRegistration);
            await _context.SaveChangesAsync();
            return userRegistration;
        }

        public async Task<User> GoogleLoginAsync(string email, string? name, string? phone, string? address, string? country)
        {
            // Busca el usuario por correo electrónico
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                // Si el usuario no existe, lo crea y guarda en la base de datos
                user = new User
                {
                    Email = email,
                    Name = name,
                    Phone = phone,
                    Address = address,
                    Country = country,
                    Status = "ACTIVE",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Si el usuario ya existe, actualiza su información
                user.Name = name;
                user.Phone = phone;
                user.Address = address;
                user.Country = country;
                user.UpdateAt = DateTime.UtcNow;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}
