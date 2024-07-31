using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CvManager.Services
{
    public class ExtraCoursesService : IExtraCoursesService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public ExtraCoursesService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(ExtraCourseVM extraCourse)
        {
            var newExtraCourse = _mapper.Map<ExtraCourse>(extraCourse);
            await _context.ExtraCourses.AddAsync(newExtraCourse);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var extraCourse = await _context.ExtraCourses.FindAsync(id);
            if (extraCourse == null)
            {
                throw new Exception($"El extraCourse con id: {id} no existe.");
            }
            if (extraCourse.Status!.ToLower() == "inactive")
            {
                throw new Exception("El extraCourse ya esta inactivo.");
            }
            extraCourse.Status = "INACTIVE";
            _context.Entry(extraCourse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExtraCourse>> GetAll()
        {
            var extraCourses = await _context.ExtraCourses.Where(e => e.Status!.ToLower().Equals("active")).ToListAsync();
            if (extraCourses.Any()) return extraCourses;
            return Enumerable.Empty<ExtraCourse>();
        }

        public async Task<IEnumerable<ExtraCourse>> GetAllDeleted()
        {
            var extraCourses = await _context.ExtraCourses.Where(e => e.Status!.ToLower().Equals("inactive")).ToListAsync();
            if (extraCourses.Any()) return extraCourses;
            return Enumerable.Empty<ExtraCourse>();
        }

        public async Task<ExtraCourse> GetById(int id)
        {
            var extraCourse = await _context.ExtraCourses.FindAsync(id);
            if (extraCourse == null) return default!;
            return extraCourse;
        }

        public async Task Restore(int id)
        {
            var extraCourse = await _context.ExtraCourses.FindAsync(id);
            if (extraCourse == null)
            {
                throw new Exception($"El extraCourse con id: {id} no existe.");
            }
            if (extraCourse.Status!.ToLower() == "active")
            {
                throw new Exception("El extraCourse ya esta activo.");
            }
            extraCourse.Status = "ACTIVE";
            _context.Entry(extraCourse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, ExtraCourseVM extraCourse)
        {
            var existingExtraCourse = await _context.ExtraCourses.FindAsync(id);
            if (existingExtraCourse == null)
            {
                throw new Exception($"El extraCourse con id: {id} no existe.");
            }
            _mapper.Map(extraCourse, existingExtraCourse);
            _context.Entry(existingExtraCourse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}