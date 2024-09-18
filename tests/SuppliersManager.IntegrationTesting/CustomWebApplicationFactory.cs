using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Driver;
using SuppliersManager.Application.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersManager.IntegrationTesting
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly MongoDbRunner _mongoRunner;

        public CustomWebApplicationFactory()
        {
            _mongoRunner = MongoDbRunner.Start(); // Iniciar MongoDB en memoria
            _mongoRunner.Import("suppliersdb", "users", "suppliersdb.users.json", false);
            _mongoRunner.Import("suppliersdb", "suppliers", "suppliersdb.suppliers.json", false);
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                // Reemplazar la configuración de MongoDB para pruebas
                services.Configure<MongoDBSettings>(options =>
                {
                    options.ConnectionURI = _mongoRunner.ConnectionString;
                    options.DatabaseName = "TestDatabase";
                });

                // Crear el cliente y el contexto de MongoDB en memoria
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var database = scope.ServiceProvider.GetRequiredService<IMongoDatabase>();
                List<string> names = new List<string>();
                var cursor = await database.ListCollectionNamesAsync();  // Asegurar que la base de datos está vacía
                await cursor.ForEachAsync(x => names.Add(x));
                var taskDropCollection = new List<Task>();
                foreach (var name in names)
                {
                    taskDropCollection.Add(database.DropCollectionAsync(name));
                }
                await Task.WhenAll(taskDropCollection);
            });
        }

        //public void Dispose()
        //{
        //    _mongoRunner.Dispose(); // Detener MongoDB en memoria al finalizar las pruebas
        //    base.Dispose();
        //}
    }
}
