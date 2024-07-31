using CvManager.Models;
using CvManager.ViewModels;

namespace CvManager.Interfaces
{
    public interface IEducationsService
    {    
        Task Add(EducationVM education);
        Task Update(int id, EducationVM education);
        Task<IEnumerable<Education>> GetAll();
        Task<Education> GetById(int id);
        Task<IEnumerable<Education>> GetAllDeleted();
        Task Delete(int id);
        Task Restore(int id);
    }
}