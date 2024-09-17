using SuppliersManager.Application.Helpers;
using SuppliersManager.Application.Interfaces.Repositories;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Application.Models.Requests;
using SuppliersManager.Application.Models.Responses.Users;
using SuppliersManager.Application.Models.Settings;
using SuppliersManager.Domain.Entities;
using SuppliersManager.Shared.Wrapper;

namespace SuppliersManager.Infrastructure.MongoDBDriver.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _pepper;
        private readonly int _iteration;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasherSettings passwordHasherSettings)
        {
            _unitOfWork = unitOfWork;
            _pepper = passwordHasherSettings.Pepper;
            _iteration = passwordHasherSettings.Iteration;
        }

        public async Task<IResult> AddAsync(UserRequest entity)
        {
            var user = new User()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                PasswordSalt = PasswordHasher.GenerateSalt(),
                UserName = entity.UserName,
            };
            user.Password = PasswordHasher.ComputeHash(
                user.Password, user.PasswordSalt, _pepper, _iteration);

            await _unitOfWork.Repository<User>().AddAsync(user);

            return await Result<string>.SuccessAsync(user.Id);
        }

        public Task<IResult> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<UserResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult<UserResponse>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(UserRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
