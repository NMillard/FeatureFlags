using System.Collections.Generic;
using System.Linq;
using FeatureToggle.Toggles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Providers.Configuration {
    public static class AppSettingsFeatureProvider {
        public static IServiceCollection AddReleaseToggles(this IServiceCollection services, string configKey, IConfiguration config) {
            services.AddTransient<IToggleRouter, ReleaseRouter>(_ => {
                IEnumerable<IConfigurationSection> toggles = config
                    .GetSection(configKey).GetChildren();

                IToggle[] featureToggles = toggles
                    .Select(section => new ReleaseToggle(section.Key, bool.Parse(section.Value)))
                    .ToArray();

                return new ReleaseRouter(featureToggles);
            });
            
            return services;
        }
    }
}