﻿namespace StudentManagementSystem.DTO.Request
{
    public class StaffRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public UserRequest UserReq { get; set; }
    }
}
