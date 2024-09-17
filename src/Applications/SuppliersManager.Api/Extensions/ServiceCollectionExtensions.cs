using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using SuppliersManager.Application.Interfaces.Services;
using SuppliersManager.Application.Models.Settings;
using SuppliersManager.Domain.Contracts;
using SuppliersManager.Infrastructure.MongoDBDriver.Services;

namespace SuppliersManager.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSettings(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));
            services.AddSingleton<IPasswordHasherSettings, PasswordHasherSettings>();
            
            return services;
        }

        internal static IServiceCollection AddMongoDatabase(
            this IServiceCollection services)
        {
            return services.AddSingleton(sp =>
            {
                var mongoSettings = sp.GetService<IOptions<MongoDBSettings>>();
                var connectionString = mongoSettings!.Value.ConnectionURI;
                var client = new MongoClient(connectionString);
                var database = mongoSettings!.Value.DatabaseName;
                return client.GetDatabase(database);
            });
        }

        internal static IServiceCollection AddMongoConfigurations(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(x => x.Id)
                  .SetIdGenerator(StringObjectIdGenerator.Instance)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            return services;
        }

        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            
            return services;
        }
    }
}
