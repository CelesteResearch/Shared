using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        public List<object> GetTrackedEntities(Type actualType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            var definition = catalog.Find(actualType) ??
                             throw new InvalidOperationException("The actual entity type is not registered: " +
                                                                 actualType.FullName);
            return GetTrackedEntities(definition.Name);
        }

        public bool TryGetTrackedEntities(Type actualType, out List<object> entities)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            var definition = catalog.Find(actualType);
            if (definition == null)
            {
                entities = null;
                return false;
            }

            return tracker.TryGetValue(definition.Name, out entities);
        }

        public T GetTrackedEntity<T>(string key) where T : class
        {
            var list = GetTrackedEntities(key);
            if (list.Count == 0) return null;
            return list[0] as T;
        }

        public T GetTrackedEntity<T>() where T : class
        {
            var list = GetTrackedEntities(typeof(T));
            return list.Count == 0 ? null : list[0] as T;
        }
    }
}
