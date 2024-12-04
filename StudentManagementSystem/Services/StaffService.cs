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
        private readonly AppDbContext _appDbContext;
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;
        private ITokenRepository _tokenRepository;

        public StaffService(AppDbContext appDbContext, IStaffRepository staffRepository, IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _appDbContext = appDbContext;
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        //public async Task<StaffResponse> AddStaff(StaffRequest request)
        //{
        //    var role = await _staffRepository.GetRoleByNameAsync("staff");
        //    if (role == null)
        //    {
        //        throw new InvalidOperationException("Role not Found");
        //    }

        //    var user = new User
        //    {
        //        Email = request.Email,
        //        Password = request.Password,
        //        UserRole = new UserRole
        //        {
        //            RoleID = role.ID,
        //        }
        //    };
        //    var userEntity = await _userRepository.AddUserAsync(user);

        //    var staff = new Staff
        //    {
        //        Id = userEntity.ID,
        //        Name = request.Name,
        //        Phone = request.Phone,
        //    };

        //    await _staffRepository.AddStaff(staff);

        //    var token = _tokenRepository.GenerateToken(user.Email, "staff");

        //    return new StaffResponse
        //    {
        //        Id = staff.Id,
        //        Name = staff.Name,
        //        Phone = staff.Phone,
        //    };
        //}


        public async Task<StaffResponse> AddStaffAsync(StaffRequest request)
        {
            var role = await _staffRepository.GetRoleByNameAsync("staff");

            if (role == null)
                throw new InvalidOperationException("Role not found.");

            // Map the User entity (no password hashing)
            var user = new User
            {
                Email = request.UserReq.Email,
                Password = request.UserReq.Password, // Directly using the provided password
                UserRole = new UserRole
                {
                    RoleID = role.ID
                }
            };

            // Start transaction to insert user and student together
            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Insert the user first
                    _appDbContext.Users.Add(user);
                    await _appDbContext.SaveChangesAsync();

                    // Create the student entity, linking to the user by user ID
                    var staff = new Staff
                    {
                        Name = request.Name,
                        Phone = request.Phone,
                        UserID = user.ID // Link the student to the user via the UserID
                    };

                    // Insert the student
                    _appDbContext.Staff.Add(staff);
                    await _appDbContext.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    // Return the student response
                    return new StaffResponse
                    {
                        Id = staff.Id,
                        Name = staff.Name,
                        Phone = staff.Phone,
                       
                    };
                }
                catch (Exception ex)
                {
                    // Rollback if an error occurs
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException("Error adding Staff and user.", ex);
                }
            }
        }




        public async Task<IEnumerable<StaffResponse>> GetStaffs()
        {
            var StaffData = await _staffRepository.GetStaffs();

            var StaffList = new List<StaffResponse>();

            foreach (var item in StaffData)
            {
                var StaffResponse = new StaffResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    UserRes = new UserResponse
                    {
                        ID = item.User.ID,
                        Email = item.User.Email
                    }
                   
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


        public async Task<StaffResponse> UpdateStaff(Guid id, StaffReqDto request)
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

        public async Task<StaffResponse> GetStaffByUserIdAsync(Guid userId)
        {
            var Staff = await _staffRepository.GetStaffByUserIdAsync(userId);

            if (Staff == null)
            {
                throw new KeyNotFoundException("Staff not found for the provided UserID.");
            }

            // Map StudentResponce with Class details
            return new StaffResponse
            {
                Id = Staff.Id,
                Name = Staff.Name,
                Phone = Staff.Phone,
                UserRes = new UserResponse
                {
                    ID = Staff.User.ID,
                    Email = Staff.User.Email
                }
            };

        }
    }
}
