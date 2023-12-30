using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace E2U.DataAccess
{
    /// <summary>
    /// DataContext used by 'dotnet ef' command line utility.
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<DataContextFactory>()
                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../F3CManager"))
                //.AddJsonFile("appsettings.json")
                .Build();

            var connectionStringKey = configuration["ConnectionStringKey"];
            if (String.IsNullOrWhiteSpace(connectionStringKey))
            {
                connectionStringKey = "SqlConnectionString";
                Console.WriteLine("'ConnectionStringKey' not found in Configuration. Using default Connection string key: ");
            }
            Console.WriteLine("ConnectionStringKey = " + connectionStringKey);

            var connectionString = configuration.GetConnectionString(connectionStringKey);
            //Console.WriteLine("connection string: " + connectionString);
            //PrintConfig(configuration);
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connectionString).EnableSensitiveDataLogging(true);

            return new DataContext(optionsBuilder.Options);
        }

        private void PrintConfig(IConfiguration configuration)
        {
            foreach(var config in configuration.AsEnumerable())
            {
                Console.WriteLine($"{config.Key}: {config.Value}");
            }
        }
    }
}