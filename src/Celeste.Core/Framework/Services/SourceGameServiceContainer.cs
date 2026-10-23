using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Services
{
    public class SourceGameServiceContainer : IServiceProvider
    {
        private Dictionary<Type, object> services = new Dictionary<Type, object>();

        public void AddService(Type type, object provider)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (provider == null) throw new ArgumentNullException("provider");
            if (!type.IsAssignableFrom(provider.GetType()))
                throw new ArgumentException("The provider does not match the specified service type!");
            services.Add(type, provider);
        }

        public object GetService(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            return services.TryGetValue(type, out var service) ? service : null;
        }

        public void RemoveService(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            services.Remove(type);
        }
    }
}
