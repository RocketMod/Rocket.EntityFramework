# Rocket.EntityFrameworkCore [![Build status](https://ci.appveyor.com/api/projects/status/n8vs6gdifa9y7x0y?svg=true)](https://ci.appveyor.com/project/RocketMod/rocket-entityframeworkcore/)

Provides EntityFrameworkCore integrations for RocketMod .NET Game Server Plugin Framework.

To use in your plugins, add `Rocket.EntityFrameworkCore` to your plugin from NuGet and then use in your Load(): 
```cs
this
  .GetEntityFrameworkCoreBuilder()
  .AddEntityFrameworkCore();
```

After that just add your normal DbContext's by extending `PluginDbContext` and this will handle the rest.