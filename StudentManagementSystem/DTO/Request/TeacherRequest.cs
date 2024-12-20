﻿using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DTO.Request
{
    public class TeacherRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid SubjectID { get; set; }

        public UserRequest UserReq { get; set; }

    }
}
