using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.IRepository
{
    public interface IStaffRepository
    {
        Task<Staff> AddStaff(Staff Staff);
        Task<List<Staff>> GetStaff();
        Task<Staff> GetStaffById(Guid id);
        Task<Staff> UpdateStaff(Guid id, StaffRequest request);
        Task<Staff> DeleteStaff(Guid id);
    }
}
