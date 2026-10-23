using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Services
{
    public class SourceGameServiceContainer : IServiceProvider
    {
        private readonly Dictionary<Type, object> _services = new();

        public void AddService(Type type, object provider)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (provider == null) throw new ArgumentNullException("provider");
            if (!type.IsAssignableFrom(provider.GetType()))
                throw new ArgumentException("The provider does not match the specified service type!");
            _services.Add(type, provider);
        }

        public object GetService(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            return _services.TryGetValue(type, out var service) ? service : null;
        }

        public void RemoveService(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            _services.Remove(type);
        }
    }
}
