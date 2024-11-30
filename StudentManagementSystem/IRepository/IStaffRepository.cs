using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IStaffRepository
    {
        Task<Staff> AddStaff(Staff Staff);
        Task<IEnumerable<Staff>> GetStaffs();
        Task<Staff> GetStaffById(Guid id);
        Task<Staff> UpdateStaff(Guid id, StaffReqDto request);
        Task<Staff> DeleteStaff(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
