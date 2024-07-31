using CvManager.Models;
using CvManager.ViewModels;

namespace CvManager.Interfaces
{
    public interface ISkillsService
    {    
        Task Add(SkillVM skill);
        Task Update(int id, SkillVM skill);
        Task<IEnumerable<Skill>> GetAll();
        Task<Skill> GetById(int id);
        Task<IEnumerable<Skill>> GetAllDeleted();
        Task Delete(int id);
        Task Restore(int id);
    }
}