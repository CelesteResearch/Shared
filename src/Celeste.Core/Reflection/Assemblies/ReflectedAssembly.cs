using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Celeste.Core.Reflection.Assemblies
{
    public sealed class ReflectedAssembly
    {
        public SourceLogicalAggregateAssembly OriginalAssembly { get; }
        public Assembly ActualAssembly { get; }
        private readonly Assembly[] _actualAssemblies;
        public string FullName => OriginalAssembly?.FullName ?? ActualAssembly.FullName;

        public ReflectedAssembly(SourceLogicalAggregateAssembly original)
        {
            OriginalAssembly = original ?? throw new ArgumentNullException(nameof(original));
        }

        public ReflectedAssembly(Assembly actual, IEnumerable<Assembly> contextAssemblies = null)
        {
            ActualAssembly = actual ?? throw new ArgumentNullException(nameof(actual));
            _actualAssemblies =
            [
                .. new[] { actual }.Concat(contextAssemblies ?? (Assembly[])[]).Distinct(),
            ];
        }

        public Type GetType(string name)
        {
            return OriginalAssembly != null
                ? OriginalAssembly.GetType(name)
                : _actualAssemblies.Select(assembly => assembly.GetType(name)).FirstOrDefault(type => type != null);
        }

        public Type[] GetTypes()
        {
            return OriginalAssembly != null
                ? OriginalAssembly.GetTypes()
                : [.. _actualAssemblies.SelectMany(assembly => assembly.GetTypes())];
        }
    }
}
