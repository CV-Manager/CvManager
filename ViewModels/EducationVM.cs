namespace CvManager.ViewModels
{
    public class EducationVM
    {
        public int UserId { get; set; }
        public string? Institution { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }

}