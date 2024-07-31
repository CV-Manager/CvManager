namespace CvManager.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[]? Image { get; set; }
        public string? ProvidedAccount { get; set; }
        public string? Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public ICollection<Education>? Educations { get; set; }
        public ICollection<ExtraCourse>? ExtraCourses { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<SocialLogin>? SocialLogins { get; set; }
        public ICollection<WorkHistory>? WorkHistories { get; set; }
    }
}