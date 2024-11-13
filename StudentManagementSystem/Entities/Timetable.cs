﻿namespace StudentManagementSystem.Entities
{
    public class Timetable
    {
        public Guid ID { get; set; }
        public Guid SubjectID { get; set; }
        public Subject Subject { get; set; }
        public Guid TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public Guid ClassID { get; set; }
        public Class Class { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
    }
}
