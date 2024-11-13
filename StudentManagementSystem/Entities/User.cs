using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public Role Role { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<OTP> OTPs { get; set; } = new List<OTP>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    }
}
