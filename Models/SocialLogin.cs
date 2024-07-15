namespace CvManager.Models
{
    public class SocialLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Provider { get; set; }
        public string? ProviderId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User? User { get; set; }
    }
}