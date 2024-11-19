using StudentManagementSystem.DTO.Request;
using StudentManagementSystem.DTO.Response;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using StudentManagementSystem.IServices;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<StaffResponse> AddStaff(StaffRequest request)
        {
            var Staff = new Staff
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Department = request.Department
            };


            var StaffData = await _staffRepository.AddStaff(Staff);

            var StaffResponse = new StaffResponse
            {
                Id = StaffData.Id,
                Name = StaffData.Name,
                Email = StaffData.Email,
                Phone = StaffData.Phone,
                Department = StaffData.Department
            };

            return StaffResponse;
        }


        public async Task<List<StaffResponse>> GetStaff()
        {
            var StaffData = await _staffRepository.GetStaff();

            var StaffList = new List<StaffResponse>();

            foreach (var item in StaffData)
            {
                var StaffResponse = new StaffResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    Department = item.Department
                };

                StaffList.Add(StaffResponse);
            }
            return StaffList;
        }


        public async Task<StaffResponse> GetStaffById(Guid id)
        {
            var StaffData = await _staffRepository.GetStaffById(id);

            var StaffResponse = new StaffResponse
            {
                Id = StaffData.Id,
                Name = StaffData.Name,
                Email = StaffData.Email,
                Phone = StaffData.Phone,
                Department = StaffData.Department
            };
            return StaffResponse;
        }


        public async Task<StaffResponse> UpdateStaff(Guid id, StaffRequest request)
        {
            var StaffData = await _staffRepository.UpdateStaff(id, request);

            var StaffResponse = new StaffResponse
            {
                Id = StaffData.Id,
                Name = StaffData.Name,
                Email = StaffData.Email,
                Phone = StaffData.Phone,
                Department = StaffData.Department
            };
            return StaffResponse;
        }


        public async Task<StaffResponse> DeleteStaff(Guid id)
        {
            var StaffData = await _staffRepository.DeleteStaff(id);

            var StaffResponse = new StaffResponse
            {
                Id = StaffData.Id,
                Name = StaffData.Name,
                Email = StaffData.Email,
                Phone = StaffData.Phone,
                Department = StaffData.Department
            };

            return StaffResponse;
        }
    }
}
