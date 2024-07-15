using CvManager.ViewModels;
using CvManager.Models;

namespace CvManager.Interfaces
{
    public interface IAccountService
    {
        Task<User> Register(RegisterVM user);
        Task<User> Login(LoginVM user);
    }
}