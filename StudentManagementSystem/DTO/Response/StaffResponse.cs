namespace StudentManagementSystem.DTO.Response
{
    public class StaffResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public UserResponse UserRes { get; set; }
    }
}
