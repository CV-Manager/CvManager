namespace CvManager.ViewModels
{
    public class WorkHistoryVM
    {
        public int UserId { get; set; }
        public string? Company { get; set; }
        public string? Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}