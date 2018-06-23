﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Rocket.API.Eventing;
using Rocket.API.Plugins;
using Rocket.Core.DependencyInjection;
using Rocket.Core.Extensions;
using Rocket.Core.Plugins.Events;
using Rocket.Core.ServiceProxies;

namespace Rocket.EntityFrameworkCore
{
    public class EntityFrameworkService : IEntityFrameworkService, IEventListener<PluginUnloadEvent>
    {
        private readonly Dictionary<IPlugin, List<PluginDbContext>> _contexts = new Dictionary<IPlugin, List<PluginDbContext>>();

        public void RegisterContextsByConvention(IPlugin plugin)
        {
            var contextTypes = plugin.FindTypes<PluginDbContext>()
                .Where(c => !c.GetCustomAttributes(typeof(DontAutoRegisterAttribute), true).Any());

            UnloadPlugin(plugin);
            _contexts.Add(plugin, new List<PluginDbContext>());

            foreach (var type in contextTypes)
            {
                var pluginContext = (PluginDbContext) plugin.Container.Activate(type);
                _contexts[plugin].Add(pluginContext);
            }
        }

        public T GetDbContext<T>(IPlugin plugin) where T : PluginDbContext
        {
            if(!_contexts.ContainsKey(plugin))
                throw new Exception("Plugin is not registered! Did you forget to use AddEntityFrameworkCore()?");

            return (T) _contexts[plugin].FirstOrDefault(c => c is T);
        }

        //unload db contexts after all other events listeners
        [Core.Eventing.EventHandler(Priority = ServicePriority.Highest)]
        public void HandleEvent(IEventEmitter emitter, PluginUnloadEvent @event)
        {
            UnloadPlugin(@event.Plugin);
        }

        private void UnloadPlugin(IPlugin plugin)
        {
            if (!_contexts.ContainsKey(plugin))
                return;

            foreach (var context in _contexts[plugin])
                context.Dispose();

            _contexts.Remove(plugin);
        }
    }
}
