using System.Reflection;
using System;
using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;
using Celeste.Scene.Tracking;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Reflection
{
    public sealed partial class
        SourceEverestReflectionProcessState : global::Celeste.Core.Reflection.Assemblies.ISourceAggregateAssemblyOrder,
        global::Celeste.Core.Reflection.Assemblies.ISourceAggregateRuntimeTypes,
        global::Celeste.Core.Reflection.Runtime.ISourceRuntimeTypeAliasResolver
    {
        private readonly ISourceEverestModulesProcessEnvironment modules;
        private readonly ISourceEverestReflectionAssemblyEnvironment assemblies;
        private global::Celeste.Core.Reflection.Assemblies.SourceLogicalAggregateAssembly entryAssembly;
        public SourceAssemblyMethodCatalog SourceMethods { get; } = new SourceAssemblyMethodCatalog();

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
            var discovery = (modules as Runtime.ISourceRuntimeTypeDiscoveryEnvironment)?.RuntimeTypeDiscovery;
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
                    string assembly = SourceMembers.GetOriginalTypeDefinition(moduleType).AssemblyIdentity;
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

        public Type ResolveRuntimeTypeAlias(string name, bool ignoreCase = false) =>
            (modules as Celeste.Everest.Reflection.Runtime.ISourceRuntimeTypeDiscoveryEnvironment)
            ?.RuntimeTypeDiscovery.ResolveRuntimeTypeAlias(name, ignoreCase);

        public bool RuntimeTypeNameMatches(Type type, string name, bool allowShortName = false,
            bool ignoreCase = false) =>
            (modules as Celeste.Everest.Reflection.Runtime.ISourceRuntimeTypeDiscoveryEnvironment)
            ?.RuntimeTypeDiscovery.RuntimeTypeNameMatches(type, name, allowShortName, ignoreCase) ?? false;

        public SourceReflectionTypeSafetyState TypeSafety { get; } = new SourceReflectionTypeSafetyState();

        public SourceEverestReflectionProcessState(ISourceEverestModulesProcessEnvironment modules,
            ISourceEverestReflectionAssemblyEnvironment assemblies,
            global::Celeste.Core.Reflection.Members.SourceMemberCatalog sourceMembers)
        {
            this.modules = modules;
            this.assemblies = assemblies;
            SourceMembers = sourceMembers ?? throw new ArgumentNullException(nameof(sourceMembers));
        }

        public global::Celeste.Core.Reflection.Assemblies.SourceLogicalAggregateAssembly GetFakeEntryAssembly()
            => entryAssembly ?? (entryAssembly =
                new global::Celeste.Core.Reflection.Assemblies.SourceLogicalAggregateAssembly(
                    assemblies.OriginalGameAssemblyIdentity, SourceMembers, SourceResources, this));
    }
}
