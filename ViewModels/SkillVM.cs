namespace CvManager.ViewModels
{
    public class SkillVM
    {
        public int UserId { get; set; }
        public string? SkillName { get; set; }
        public string? ProficiencyLevel { get; set; }
        public string? Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}