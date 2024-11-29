using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
