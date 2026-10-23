using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Assemblies;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Runtime;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Reflection.Runtime;

namespace Celeste.Everest.Reflection
{
    public sealed partial class
        SourceEverestReflectionProcessState : ISourceAggregateAssemblyOrder,
        ISourceAggregateRuntimeTypes,
        ISourceRuntimeTypeAliasResolver
    {
        private readonly ISourceEverestModulesProcessEnvironment modules;
        private readonly ISourceEverestReflectionAssemblyEnvironment assemblies;
        private SourceLogicalAggregateAssembly entryAssembly;
        public SourceAssemblyMethodCatalog SourceMethods { get; } = new();

        public IEnumerable<string> GetOriginalAggregateAssemblyOrder()
        {
            var seen = new HashSet<string>(StringComparer.Ordinal);
            foreach (var module in modules.ModulesProcess.Modules)
            {
                if (!SourceMembers.ContainsSourceType(module.GetType())) continue;
                var identity = SourceMembers.GetOriginalTypeDefinition(module.GetType()).AssemblyIdentity;
                if (seen.Add(identity)) yield return identity;
            }
        }

        public IEnumerable<Type> GetAggregateRuntimeTypes()
        {
            var seenLogical = new HashSet<string>(StringComparer.Ordinal);
            var seenActual = new HashSet<Assembly>();
            var discovery = (modules as ISourceRuntimeTypeDiscoveryEnvironment)?.RuntimeTypeDiscovery;
            foreach (var module in modules.ModulesProcess.Modules)
            {
                var moduleType = module.GetType();
                if (SourceMembers.ContainsSourceType(moduleType))
                {
                    var identity = SourceMembers.GetOriginalTypeDefinition(moduleType).AssemblyIdentity;
                    if (!seenLogical.Add(identity)) continue;
                    foreach (var type in SourceMembers.GetRuntimeAssemblyTypes(identity)) yield return type;
                }
                else if (seenActual.Add(moduleType.Assembly))
                {
                    foreach (var type in discovery != null
                                 ? discovery.GetAssemblyTypes(moduleType.Assembly)
                                 : moduleType.Assembly.GetTypes()) yield return type;
                }
            }
        }

        public Type GetAggregateRuntimeType(string name, bool ignoreCase)
        {
            foreach (var module in modules.ModulesProcess.Modules)
            {
                var moduleType = module.GetType();
                if (SourceMembers.ContainsSourceType(moduleType))
                {
                    var assembly = SourceMembers.GetOriginalTypeDefinition(moduleType).AssemblyIdentity;
                    if (ignoreCase)
                    {
                        foreach (var definition in SourceMembers.OriginalTypeDefinitions)
                            if (definition.AssemblyIdentity == assembly &&
                                string.Equals(definition.Identity, name, StringComparison.OrdinalIgnoreCase))
                                return SourceMembers.GetActualSourceType(assembly, definition.Identity);
                    }
                    else
                    {
                        var type = SourceMembers.GetActualSourceType(assembly, name);
                        if (type != null) return type;
                    }
                }
                else
                {
                    var type = moduleType.Assembly.GetType(name, false, ignoreCase);
                    if (type != null) return type;
                }
            }

            return null;
        }

        public Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false)
        {
            return (modules as ISourceRuntimeTypeDiscoveryEnvironment)
                ?.RuntimeTypeDiscovery.ResolveRuntimeTypeAlias(name, ignoreCase);
        }

        public bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false,
            bool ignoreCase = false)
        {
            return (modules as ISourceRuntimeTypeDiscoveryEnvironment)
                ?.RuntimeTypeDiscovery.RuntimeTypeNameMatches(type, name, allowShortName, ignoreCase) ?? false;
        }

        public SourceReflectionTypeSafetyState TypeSafety { get; } = new();

        public SourceEverestReflectionProcessState(ISourceEverestModulesProcessEnvironment modules,
            ISourceEverestReflectionAssemblyEnvironment assemblies,
            SourceMemberCatalog sourceMembers)
        {
            this.modules = modules;
            this.assemblies = assemblies;
            SourceMembers = sourceMembers ?? throw new ArgumentNullException(nameof(sourceMembers));
        }

        public SourceLogicalAggregateAssembly GetFakeEntryAssembly()
        {
            return entryAssembly ?? (entryAssembly =
                new(
                    assemblies.OriginalGameAssemblyIdentity, SourceMembers, SourceResources, this));
        }
    }
}
