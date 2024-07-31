using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CvManager.Services
{
    public class WorkHistoriesService : IWorkHistoriesService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public WorkHistoriesService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(WorkHistoryVM workHistory)
        {
            var newWorkHistory = _mapper.Map<WorkHistory>(workHistory);
            await _context.WorkHistories.AddAsync(newWorkHistory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory == null)
            {
                throw new Exception($"La workHistory con id: {id} no existe.");
            }
            if (workHistory.Status!.ToLower() == "inactive")
            {
                throw new Exception("La workHistory ya esta inactiva.");
            }
            workHistory.Status = "INACTIVE";
            _context.Entry(workHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkHistory>> GetAll()
        {
            var workHistories = await _context.WorkHistories.Where(e => e.Status!.ToLower().Equals("active")).ToListAsync();
            if (workHistories.Any()) return workHistories;
            return Enumerable.Empty<WorkHistory>();
        }

        public async Task<IEnumerable<WorkHistory>> GetAllDeleted()
        {
            var workHistories = await _context.WorkHistories.Where(e => e.Status!.ToLower().Equals("inactive")).ToListAsync();
            if (workHistories.Any()) return workHistories;
            return Enumerable.Empty<WorkHistory>();
        }

        public async Task<WorkHistory> GetById(int id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory == null) return default!;
            return workHistory;
        }

        public async Task Restore(int id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory == null)
            {
                throw new Exception($"La workHistory con id: {id} no existe.");
            }
            if (workHistory.Status!.ToLower() == "active")
            {
                throw new Exception("La workHistory ya esta activa.");
            }
            workHistory.Status = "ACTIVE";
            _context.Entry(workHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, WorkHistoryVM workHistory)
        {
            var existingWorkHistory = await _context.WorkHistories.FindAsync(id);
            if (existingWorkHistory == null)
            {
                throw new Exception($"La workHistory con id: {id} no existe.");
            }
            _mapper.Map(workHistory, existingWorkHistory);
            _context.Entry(existingWorkHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}