using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Core.Reflection.Assemblies
{
    public sealed class ReflectedAssembly
    {
        public SourceLogicalAggregateAssembly OriginalAssembly { get; }
        public Assembly ActualAssembly { get; }
        private readonly Assembly[] actualAssemblies;
        public string FullName => OriginalAssembly?.FullName ?? ActualAssembly.FullName;

        public ReflectedAssembly(SourceLogicalAggregateAssembly original)
            => OriginalAssembly = original ?? throw new ArgumentNullException(nameof(original));

        public ReflectedAssembly(Assembly actual, IEnumerable<Assembly> contextAssemblies = null)
        {
            ActualAssembly = actual ?? throw new ArgumentNullException(nameof(actual));
            actualAssemblies = new[] { actual }.Concat(contextAssemblies ?? Array.Empty<Assembly>()).Distinct()
                .ToArray();
        }

        public Type GetType(string name) => OriginalAssembly != null
            ? OriginalAssembly.GetType(name)
            : actualAssemblies.Select(assembly => assembly.GetType(name)).FirstOrDefault(type => type != null);

        public Type[] GetTypes() => OriginalAssembly != null
            ? OriginalAssembly.GetTypes()
            : actualAssemblies.SelectMany(assembly => assembly.GetTypes()).ToArray();
    }
}
