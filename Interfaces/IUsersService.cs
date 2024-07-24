using CvManager.ViewModels;
using CvManager.Models;

namespace CvManager.Interfaces
{
    public interface IUsersService
    {
        Task Update(int id, UserVM user);
        Task Delete(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAllDeleted();
        Task<User> Restore(int id);
    }
}