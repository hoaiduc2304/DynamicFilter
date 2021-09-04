using DNH.Infrastructure.Database.SQL;
using DNHCore.StartUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFilter
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //add NopConfig configuration parameters
            services.ConfigureStartupConfig<DBConfiguration>(configuration.GetSection("DBConfiguration"));
            //add hosting configuration parameters
          
            var provider = services.BuildServiceProvider();
            var dnhConfig = provider.GetRequiredService<DBConfiguration>();
            DBConfiguration.Setting = dnhConfig;

            /*startup*/
            var typeFinder = new AppDomainTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<IDNHStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                //.Where(startup => PluginManager.FindPlugin(startup)?.Installed ?? true) //ignore not installed plugins
                .Select(startup => (IDNHStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            //configure services
            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);

        }
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }
    }
}
