using System.IO;
using FeatureToggle.Providers.Configuration;
using FeatureToggle.Toggles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

IServiceCollection services = new ServiceCollection();
services.AddReleaseToggles("Toggles", config);

var flags = services.BuildServiceProvider().GetRequiredService<IToggleRouter>();

bool isEnabled = flags.IsEnabled(nameof(ToggleKey.OtherToggle));
bool isEnabled2 = flags.IsEnabled(nameof(ToggleKey.NewUserType));

System.Console.WriteLine();