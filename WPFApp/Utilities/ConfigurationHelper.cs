using Microsoft.Extensions.Configuration;
using System.IO;

namespace WPFApp.Utilities
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
