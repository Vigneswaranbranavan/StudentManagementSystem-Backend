using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface IStaffService
    {
        Task<StaffResponse> AddStaff(StaffRequest request);
        Task<List<StaffResponse>> GetStaff();
        Task<StaffResponse> GetStaffById(Guid id);
        Task<StaffResponse> UpdateStaff(Guid id, StaffRequest request);
        Task<StaffResponse> DeleteStaff(Guid id);
    }
}
