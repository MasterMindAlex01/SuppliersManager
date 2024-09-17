using SuppliersManager.Application.Models.Requests;
using SuppliersManager.Application.Models.Responses.Users;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IResult<UserResponse>> GetByIdAsync(string id);

        Task<IResult<List<UserResponse>>> GetAllAsync();

        Task<IResult> AddAsync(UserRequest entity);

        Task<IResult> UpdateAsync(UserRequest entity);

        Task<IResult> DeleteAsync(string id);
    }
}
