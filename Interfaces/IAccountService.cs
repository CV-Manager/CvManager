using CvManager.ViewModels;
using CvManager.Models;

namespace CvManager.Interfaces
{
    public interface IAccountService
    {
        Task<User> Register(RegisterVM user);
        Task<User> Login(LoginVM user);
        Task<User> GoogleLoginAsync(string email, string? name, string? phone, string? address, string? country);
    }
}
