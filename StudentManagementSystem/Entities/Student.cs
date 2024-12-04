using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entities
{
    public class Student
    {

        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string IndexNumber { get; set; }
        public Gender gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassID { get; set; }
        public Class Class { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        public enum Gender
        {
            none = 0,
            male = 1,
            female = 2,
            other = 3
        }
    }
}
