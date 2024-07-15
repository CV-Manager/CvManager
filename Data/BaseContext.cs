using Microsoft.EntityFrameworkCore;
using CvManager.Models;

namespace CvManager.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
        
    }
    //conexicón con modelos
    public DbSet<User> Users { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<ExtraCourse> ExtraCourses { get; set; }
    public DbSet<SocialLogin> SocialLogins { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<WorkHistory> WorkHistories { get; set; }

} 