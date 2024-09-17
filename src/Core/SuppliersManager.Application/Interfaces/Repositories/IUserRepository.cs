using SuppliersManager.Application.Models.Responses.Users;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> GetUserByUserNameAsync(string username);
    }
}
