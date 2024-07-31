using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CvManager.Services
{
    public class EducationsService : IEducationsService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public EducationsService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(EducationVM education)
        {
            var newEducation = _mapper.Map<Education>(education);
            await _context.Educations.AddAsync(newEducation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                throw new Exception($"La education con id: {id} no existe.");
            }
            if (education.Status!.ToLower() == "inactive")
            {
                throw new Exception("La education ya esta inactiva.");
            }
            education.Status = "INACTIVE";
            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Education>> GetAll()
        {
            var educations = await _context.Educations.Where(e => e.Status!.ToLower().Equals("active")).ToListAsync();
            if (educations.Any()) return educations;
            return Enumerable.Empty<Education>();
        }

        public async Task<IEnumerable<Education>> GetAllDeleted()
        {
            var educations = await _context.Educations.Where(e => e.Status!.ToLower().Equals("inactive")).ToListAsync();
            if (educations.Any()) return educations;
            return Enumerable.Empty<Education>();
        }

        public async Task<Education> GetById(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return default!;
            return education;
        }

        public async Task Restore(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                throw new Exception($"La education con id: {id} no existe.");
            }
            if (education.Status!.ToLower() == "active")
            {
                throw new Exception("La education ya esta activa.");
            }
            education.Status = "ACTIVE";
            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, EducationVM education)
        {
            var existingEducation = await _context.Educations.FindAsync(id);
            if (existingEducation == null)
            {
                throw new Exception($"La education con id: {id} no existe.");
            }
            _mapper.Map(education, existingEducation);
            _context.Entry(existingEducation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}