using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;

namespace StudentManagementSystem.IServices
{
    public interface IStaffService
    {
        Task<StaffResponse> AddStaffAsync(StaffRequest request);
        Task<IEnumerable<StaffResponse>> GetStaffs();
        Task<StaffResponse> GetStaffById(Guid id);
        Task<StaffResponse> UpdateStaff(Guid id, StaffReqDto request);
        Task<StaffResponse> DeleteStaff(Guid id);
    }
}
