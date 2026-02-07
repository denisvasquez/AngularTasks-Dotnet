using Backend.APITasksManager.Requests;
using Backend.APITasksManager.Responses;

namespace Backend.APITasksManager.IRepository
{
    public interface IUsersRepository
    {
        public Task<RegisterUserResponse> RegisterUser(CreateUserRequest request);
        public Task<LoginResponse> Login(CreateUserRequest request);
    }
}
