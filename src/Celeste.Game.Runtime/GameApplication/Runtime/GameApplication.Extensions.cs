using System;
using System.Collections.Generic;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRuntimeExtensionEnvironment
    {
        private readonly Dictionary<Type, object> runtimeExtensions = new();

        public T? GetRuntimeExtension<T>() where T : class
        {
            return runtimeExtensions.TryGetValue(typeof(T), out var extension) ? (T)extension : null;
        }

        public void RegisterRuntimeExtension(object extension)
        {
            var type = extension.GetType();
            var contracts = new List<Type>(type.GetInterfaces()) { type };
            foreach (var contract in contracts)
                if (runtimeExtensions.ContainsKey(contract))
                    throw new InvalidOperationException($"A runtime extension already implements {contract.FullName}.");
            foreach (var contract in contracts) runtimeExtensions.Add(contract, extension);
        }

        public void UnregisterRuntimeExtension(object extension)
        {
            var keys = new List<Type>();
            foreach (var pair in runtimeExtensions)
                if (ReferenceEquals(pair.Value, extension))
                    keys.Add(pair.Key);
            foreach (var key in keys) runtimeExtensions.Remove(key);
        }
    }
}
