﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entities
{
    public class Student
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassID { get; set; }
        public Class Class { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();


    }
}
