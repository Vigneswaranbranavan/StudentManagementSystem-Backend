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
        private readonly IUserRepository _userRepository;
        private ITokenRepository _tokenRepository;

        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<StaffResponse> AddStaff(StaffRequest request)
        {
            var role = await _staffRepository.GetRoleByNameAsync("staff");
            if (role == null)
            {
                throw new InvalidOperationException("Role not Found");
            }

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                UserRole = new UserRole
                {
                    RoleID = role.ID,
                }
            };
            var userEntity = await _userRepository.AddUserAsync(user);

            var staff = new Staff
            {
                Id = userEntity.ID,
                Name = request.Name,
                Phone = request.Phone,
            };

            await _staffRepository.AddStaff(staff);

            var token = _tokenRepository.GenerateToken(user.Email, "staff");

            return new StaffResponse
            {
                Id = staff.Id,
                Name = staff.Name,
                Phone = staff.Phone,
            };
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
                    Phone = item.Phone,
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
                Phone = StaffData.Phone,
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
                Phone = StaffData.Phone,
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
                Phone = StaffData.Phone,
            };

            return StaffResponse;
        }
    }
}
