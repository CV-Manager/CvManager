using CvManager.Data;
using CvManager.Interfaces;
using CvManager.Models;
using CvManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CvManager.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public SkillsService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(SkillVM skill)
        {
            var newSkill = _mapper.Map<Skill>(skill);
            await _context.Skills.AddAsync(newSkill);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                throw new Exception($"La skill con id: {id} no existe.");
            }
            if (skill.Status!.ToLower() == "inactive")
            {
                throw new Exception("La skill ya esta inactiva.");
            }
            skill.Status = "INACTIVE";
            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            var skills = await _context.Skills.Where(e => e.Status!.ToLower().Equals("active")).ToListAsync();
            if (skills.Any()) return skills;
            return Enumerable.Empty<Skill>();
        }

        public async Task<IEnumerable<Skill>> GetAllDeleted()
        {
            var skills = await _context.Skills.Where(e => e.Status!.ToLower().Equals("inactive")).ToListAsync();
            if (skills.Any()) return skills;
            return Enumerable.Empty<Skill>();
        }

        public async Task<Skill> GetById(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return default!;
            return skill;
        }

        public async Task Restore(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                throw new Exception($"La skill con id: {id} no existe.");
            }
            if (skill.Status!.ToLower() == "active")
            {
                throw new Exception("La skill ya esta activa.");
            }
            skill.Status = "ACTIVE";
            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, SkillVM skill)
        {
            var existingSkill = await _context.Skills.FindAsync(id);
            if (existingSkill == null)
            {
                throw new Exception($"La skill con id: {id} no existe.");
            }
            _mapper.Map(skill, existingSkill);
            _context.Entry(existingSkill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}