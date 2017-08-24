using Microsoft.Extensions.Configuration;

namespace Npgsql.ConfigureConnection
{
    public static class NpgsqlConnectionStringBuilderConfigureExtensions
    {
        public static NpgsqlConnectionStringBuilder Configure(this NpgsqlConnectionStringBuilder builder, IConfigurationSection section)
        {
            foreach (var kvp in section.GetChildren())
                builder[kvp.Key] = kvp.Value;

            return builder;
        }
    }
}
