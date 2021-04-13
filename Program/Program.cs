using System;
using System.Collections.Generic;
using System.IO;
using FeatureToggle;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var toggles = new List<Toggle>();
config.Bind("FeatureToggles", toggles);

IServiceCollection services = new ServiceCollection();
services.AddTransient(_ => toggles);
services.AddTransient<IFeatureFlags, FeatureFlags>();

var flags = services.BuildServiceProvider().GetRequiredService<IFeatureFlags>();
bool isEnabled = flags.IsEnabled("OtherKey");

Console.WriteLine(isEnabled);