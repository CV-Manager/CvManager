using CvManager.Models;
using CvManager.ViewModels;

namespace CvManager.Interfaces
{
    public interface IWorkHistoriesService
    {
        Task Add(WorkHistoryVM workHistory);
        Task Update(int id, WorkHistoryVM workHistory);
        Task<IEnumerable<WorkHistory>> GetAll();
        Task<WorkHistory> GetById(int id);
        Task<IEnumerable<WorkHistory>> GetAllDeleted();
        Task Delete(int id);
        Task Restore(int id);
    }
}