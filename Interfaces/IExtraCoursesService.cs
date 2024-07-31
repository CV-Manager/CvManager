using CvManager.Models;
using CvManager.ViewModels;

namespace CvManager.Interfaces
{
    public interface IExtraCoursesService
    {
        Task Add(ExtraCourseVM extraCourse);
        Task Update(int id, ExtraCourseVM extraCourse);
        Task<IEnumerable<ExtraCourse>> GetAll();
        Task<ExtraCourse> GetById(int id);
        Task<IEnumerable<ExtraCourse>> GetAllDeleted();
        Task Delete(int id);
        Task Restore(int id);
    }
}