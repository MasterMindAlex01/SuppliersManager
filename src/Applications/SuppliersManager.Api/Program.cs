using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SuppliersManager.Api.Extensions;
using SuppliersManager.Application.Extensions;
using SuppliersManager.Infrastructure.MongoDBDriver.Extensions;
using System.Text;

namespace SuppliersManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();
            builder.Services.AddControllers();

            builder.Services.AddCurrentUserService();
            // Add services to the container.
            builder.Services.AddSettings(builder.Configuration);
            //AddDatabase
            builder.Services.AddMongoDatabase().AddMongoConfigurations();
            //Configurations Application Layer
            builder.Services.AddApplicationLayer();

            builder.Services.AddRepositories();

            builder.Services.AddApplicationServices();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.RegisterSwagger();

            builder.Services.AddJwtAuthentication(builder.Configuration);

            var app = builder.Build();

            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
