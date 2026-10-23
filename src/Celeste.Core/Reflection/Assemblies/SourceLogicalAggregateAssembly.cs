using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Resources;

namespace Celeste.Core.Reflection.Assemblies
{
    // A logical source assembly view is deliberately not a CLR Assembly. Its universe
    // is the published original PE and its actual bindings, independent of DLL layout.
    public sealed class SourceLogicalAggregateAssembly
    {
        private readonly SourceMemberCatalog members;
        private readonly SourceAssemblyResourceCatalog resources;
        private readonly ISourceAggregateAssemblyOrder order;
        public string FullName { get; }

        public SourceLogicalAggregateAssembly(string originalGameAssemblyIdentity, SourceMemberCatalog members,
            SourceAssemblyResourceCatalog resources, ISourceAggregateAssemblyOrder order)
        {
            FullName = originalGameAssemblyIdentity ??
                       throw new ArgumentNullException(nameof(originalGameAssemblyIdentity));
            this.members = members ?? throw new ArgumentNullException(nameof(members));
            this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
            this.order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public IEnumerable<SourceTypeDefinition> GetOriginalTypeDefinitions()
        {
            foreach (string assembly in order.GetOriginalAggregateAssemblyOrder())
            foreach (var definition in members.OriginalTypeDefinitions.Where(type => type.AssemblyIdentity == assembly)
                         .OrderBy(type => type.MetadataToken))
                if (definition.Identity != "<Module>")
                    yield return definition;
        }

        public Type[] GetTypes() => order is ISourceAggregateRuntimeTypes runtime
            ? runtime.GetAggregateRuntimeTypes().ToArray()
            : order.GetOriginalAggregateAssemblyOrder().SelectMany(members.GetRuntimeAssemblyTypes).ToArray();

        public Type[] GetExportedTypes() => GetTypes()
            .Where(type => members.ContainsSourceType(type)
                ? IsExternallyVisible(members.GetOriginalTypeDefinition(type))
                : type.IsVisible).ToArray();

        private bool IsExternallyVisible(SourceTypeDefinition type)
        {
            int visibility = type.Attributes & (int)TypeAttributes.VisibilityMask;
            if (visibility == (int)TypeAttributes.Public) return true;
            if (visibility != (int)TypeAttributes.NestedPublic) return false;
            int nested = type.Identity.LastIndexOf('+');
            if (nested < 0) throw new InvalidOperationException("Nested source type has no declaring type identity.");
            return IsExternallyVisible(
                members.GetOriginalTypeDefinition(type.AssemblyIdentity, type.Identity[..nested]));
        }

        public Type GetType(string name, bool throwOnError = false, bool ignoreCase = false)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (order is ISourceAggregateRuntimeTypes runtime)
            {
                var type = runtime.GetAggregateRuntimeType(name, ignoreCase);
                if (type != null) return type;
            }
            else
                foreach (string assembly in order.GetOriginalAggregateAssemblyOrder())
                {
                    if (ignoreCase)
                    {
                        var definition = members.OriginalTypeDefinitions.FirstOrDefault(type =>
                            type.AssemblyIdentity == assembly && string.Equals(type.Identity, name, comparison));
                        if (definition != null) return members.GetActualSourceType(assembly, definition.Identity);
                    }
                    else
                    {
                        var type = members.GetActualSourceType(assembly, name);
                        if (type != null) return type;
                    }
                }

            if (ignoreCase)
            {
                var gameType = members.OriginalTypeDefinitions.FirstOrDefault(type =>
                    type.AssemblyIdentity == FullName && string.Equals(type.Identity, name, comparison));
                if (gameType != null) return members.GetActualSourceType(FullName, gameType.Identity);
            }
            else
            {
                var gameType = members.GetActualSourceType(FullName, name);
                if (gameType != null) return gameType;
            }

            if (order is Celeste.Core.Reflection.Runtime.ISourceRuntimeTypeAliasResolver aliases)
            {
                var aliasType = aliases.ResolveRuntimeTypeAlias(name, ignoreCase);
                if (aliasType != null) return aliasType;
            }

            if (throwOnError)
                throw new TypeLoadException("Could not load type '" + name + "' from original source assembly '" +
                                            FullName + "'.");
            return null;
        }

        public bool NameMatches(Type type, string name, bool allowShortName = false, bool ignoreCase = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (name == null) return false;
            var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (string.Equals(type.FullName, name, comparison) ||
                allowShortName && string.Equals(type.Name, name, comparison)) return true;
            if (members.ContainsSourceType(type))
            {
                string logicalName = members.GetOriginalTypeFullName(type);
                if (string.Equals(logicalName, name, comparison)) return true;
                if (allowShortName)
                {
                    int separator = Math.Max(logicalName.LastIndexOf('.'), logicalName.LastIndexOf('+'));
                    if (string.Equals(logicalName.Substring(separator + 1), name, comparison)) return true;
                }
            }

            return order is Celeste.Core.Reflection.Runtime.ISourceRuntimeTypeAliasResolver aliases &&
                   aliases.RuntimeTypeNameMatches(type, name, allowShortName, ignoreCase);
        }

        public string[] GetManifestResourceNames() => resources.GetManifestResourceNames(FullName);
        public Stream GetManifestResourceStream(string name) => resources.GetManifestResourceStream(FullName, name);

        public Stream GetManifestResourceStream(Type type, string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (!members.ContainsSourceType(type)) return type.Assembly.GetManifestResourceStream(type, name);
            string identity = members.GetOriginalTypeFullName(type);
            int nested = identity.IndexOf('+');
            if (nested >= 0) identity = identity[..nested];
            int separator = identity.LastIndexOf('.');
            return GetManifestResourceStream(separator < 0 ? name : identity[..separator] + "." + name);
        }

        public AssemblyName GetName() => new AssemblyName(FullName);
    }
}
