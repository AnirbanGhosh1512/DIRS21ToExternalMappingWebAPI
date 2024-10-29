using System;
using System.Collections.Generic;
using DIRS21ToExternalMapperSystem.MapperInterface;
using Microsoft.Extensions.Logging;

namespace DIRS21ToExternslMapperWebAPI.Registry
{
                                                                                                                                                                                                                                   
    public class MapperRegistry
    {                                                                               
        private readonly Dictionary<string, IMapperStrategy> _strategies = new();
        private readonly ILogger<MapperRegistry> _logger;

        public MapperRegistry(ILogger<MapperRegistry> logger = null)
        {
            _logger = logger;
            _logger?.LogInformation("MapperRegistry instantiated.");
        }

        public void RegisterMapper(string sourceType, string targetType, IMapperStrategy strategy)
        {
            var key = $"{sourceType}To{targetType}";                                                                                                       
            if (!_strategies.ContainsKey(key))
            {
                _strategies[key] = strategy;
                _logger?.LogInformation($"Registered mapper for {sourceType} to {targetType}");
            }
            else
            {
                _logger?.LogWarning($"A mapper for {sourceType} to {targetType} is already registered.");
            }
        }

        public IMapperStrategy GetMapper(string sourceType, string targetType)
        {
            var key = $"{sourceType}To{targetType}";
            if (_strategies.TryGetValue(key, out var strategy))
            {
                return strategy;
            }

            throw new InvalidOperationException($"No mapper found for {sourceType} to {targetType}");
        }

        public int GetRegisteredCount()
        {
            return _strategies.Count;
        }
    }


}

