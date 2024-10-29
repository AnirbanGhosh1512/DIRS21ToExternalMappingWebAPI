using System;
using DIRS21ToExternslMapperWebAPI.Registry;

namespace DIRS21ToExternalMapperSystem.Handler
{
    public class MapHandler
    {
        private readonly MapperRegistry _mapperRegistry;

        public MapHandler(MapperRegistry mapperRegistry)
        {
            _mapperRegistry = mapperRegistry;
        }

        // Auto-select mapper based on source and target types
        public object Map(object source, string sourceType, string targetType)
        {
            var strategy = _mapperRegistry.GetMapper(sourceType, targetType);
            return strategy.Map(source);
        }
    }

}

