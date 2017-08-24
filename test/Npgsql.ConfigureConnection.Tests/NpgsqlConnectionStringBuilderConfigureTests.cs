using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Npgsql.ConfigureConnection.Tests
{
    public class NpgsqlConnectionStringBuilderConfigureTests
    {
        public NpgsqlConnectionStringBuilderConfigureTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        [Fact]
        public void BasicTest()
        {
            var connectionString = new NpgsqlConnectionStringBuilder()
                .Configure(Configuration.GetSection("Connections").GetSection("Basic"))
                .ToString();
            Assert.Equal(connectionString, "Database=Test;Host=localhost;Password=postgres;Port=5432;Username=postgres");
        }
    }
}
