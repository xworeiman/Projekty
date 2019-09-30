using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GRC.Test.Utils
{
    static class ConfigurationManager
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            outputPath ??= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("73c8a925-04a7-4fae-9a83-b7c7e638dce9")
                .AddEnvironmentVariables()
                .Build();
        }

        public static GrcConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new GrcConfiguration();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig.GetSection("GrcConfiguration")
                .Bind(configuration);

            return configuration;
        }
    }
}
