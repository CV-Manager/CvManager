using CvManager.ViewModels;
using CvManager.Models;

namespace CvManager.Interfaces
{
    public interface IUsersService
    {
        Task<User> Update(int id, UserVM user);
        Task<User> Delete(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAllDeleted();
        Task<User> Restore(int id);
    }
}