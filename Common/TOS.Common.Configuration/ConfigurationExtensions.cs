using Microsoft.Extensions.Configuration;

namespace TOS.Common.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T GetConfig<T>(this IConfiguration configuration)
        {
            IConfigurationSection configurationSection = configuration.GetSection(typeof(T).Name);
            T section = configurationSection.Get<T>();
            return section;
        }
    }
}
