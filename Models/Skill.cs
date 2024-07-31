namespace CvManager.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? SkillName { get; set; }
        public string? ProficiencyLevel { get; set; }
        public string? Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public User? User { get; set; }
    }
}