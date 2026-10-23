namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        public System.Collections.Generic.List<object> GetTrackedEntities(System.Type actualType)
        {
            if (actualType == null) throw new System.ArgumentNullException(nameof(actualType));
            var definition = catalog.Find(actualType) ??
                             throw new System.InvalidOperationException("The actual entity type is not registered: " +
                                                                        actualType.FullName);
            return GetTrackedEntities(definition.Name);
        }

        public bool TryGetTrackedEntities(System.Type actualType, out System.Collections.Generic.List<object> entities)
        {
            if (actualType == null) throw new System.ArgumentNullException(nameof(actualType));
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
