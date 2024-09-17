using MongoDB.Driver;
using SuppliersManager.Application.Interfaces.Repositories;
using SuppliersManager.Application.Models.Responses.Users;
using SuppliersManager.Domain.Entities;

namespace SuppliersManager.Infrastructure.MongoDBDriver.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("users");
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _collection.Find(x => x.UserName == username).FirstOrDefaultAsync();
        }
    }
}
