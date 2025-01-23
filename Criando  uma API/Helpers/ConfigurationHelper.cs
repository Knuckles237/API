using Microsoft.Extensions.Configuration;
using System;
using System.IO;
namespace WebApplication1.Helpers
{
    public static class ConfigurationHelper
    {
        private static IConfigurationRoot Configuration { get; }
        static ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }
        public static T GetAppSetting<T>(string key)
        {
            var value = Configuration[key];
            if (value == null)
            {
                throw new ArgumentException($"Chave de configuração '{key}' não encontrada no appsettings.json.");
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}