using TestTask.DataAccess.Enums;
using TestTask.DataAccess.Models;
using TestTask.DataAccess.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUser()
        {
            return _userRepository.GetUserWithLargestOrdersCount();
        }

        public Task<List<User>> GetUsers()
        {
            return _userRepository.GetUsersByStatus(UserStatus.Inactive);
        }
    }
}
