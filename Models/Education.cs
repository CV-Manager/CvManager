namespace CvManager.Models
{
    public class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Institution { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User? User { get; set; }
    }

}