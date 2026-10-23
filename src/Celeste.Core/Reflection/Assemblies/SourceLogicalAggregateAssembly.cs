using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Resources;
using Celeste.Core.Reflection.Runtime;

namespace Celeste.Core.Reflection.Assemblies
{
    // A logical source assembly view is deliberately not a CLR Assembly. Its universe
    // is the published original PE and its actual bindings, independent of DLL layout.
    public sealed class SourceLogicalAggregateAssembly
    {
        private readonly SourceMemberCatalog _members;
        private readonly SourceAssemblyResourceCatalog _resources;
        private readonly ISourceAggregateAssemblyOrder _order;
        public string FullName { get; }

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceLogicalAggregateAssembly(string originalGameAssemblyIdentity, SourceMemberCatalog members,
            SourceAssemblyResourceCatalog resources, ISourceAggregateAssemblyOrder order)
        {
            FullName = originalGameAssemblyIdentity ??
                       throw new ArgumentNullException(nameof(originalGameAssemblyIdentity));
            _members = members ?? throw new ArgumentNullException(nameof(members));
            _resources = resources ?? throw new ArgumentNullException(nameof(resources));
            _order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public IEnumerable<SourceTypeDefinition> GetOriginalTypeDefinitions()
        {
            foreach (var assembly in _order.GetOriginalAggregateAssemblyOrder())
            foreach (var definition in _members.OriginalTypeDefinitions.Where(type => type.AssemblyIdentity == assembly)
                         .OrderBy(type => type.MetadataToken))
                if (definition.Identity != "<Module>")
                    yield return definition;
        }

        public Type[] GetTypes()
        {
            return _order is ISourceAggregateRuntimeTypes runtime
                ? [.. runtime.GetAggregateRuntimeTypes()]
                : [.. _order.GetOriginalAggregateAssemblyOrder().SelectMany(_members.GetRuntimeAssemblyTypes)];
        }

        public Type[] GetExportedTypes()
        {
            return
            [
                .. GetTypes().Where(type =>
                    _members.ContainsSourceType(type)
                        ? IsExternallyVisible(_members.GetOriginalTypeDefinition(type))
                        : type.IsVisible),
            ];
        }

        private bool IsExternallyVisible(SourceTypeDefinition type)
        {
            var visibility = type.Attributes & (int)TypeAttributes.VisibilityMask;
            if (visibility == (int)TypeAttributes.Public)
                return true;
            if (visibility != (int)TypeAttributes.NestedPublic)
                return false;
            var nested = type.Identity.LastIndexOf('+');
            if (nested < 0)
                throw new InvalidOperationException("Nested source type has no declaring type identity.");
            return IsExternallyVisible(
                _members.GetOriginalTypeDefinition(type.AssemblyIdentity, type.Identity[..nested]));
        }

        public Type GetType(string name, bool throwOnError = false, bool ignoreCase = false)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (_order is ISourceAggregateRuntimeTypes runtime)
            {
                var type = runtime.GetAggregateRuntimeType(name, ignoreCase);
                if (type != null)
                    return type;
            }
            else
            {
                foreach (var assembly in _order.GetOriginalAggregateAssemblyOrder())
                    if (ignoreCase)
                    {
                        var definition = _members.OriginalTypeDefinitions.FirstOrDefault(type =>
                            type.AssemblyIdentity == assembly && string.Equals(type.Identity, name, comparison));
                        if (definition != null)
                            return _members.GetActualSourceType(assembly, definition.Identity);
                    }
                    else
                    {
                        var type = _members.GetActualSourceType(assembly, name);
                        if (type != null)
                            return type;
                    }
            }

            if (ignoreCase)
            {
                var gameType = _members.OriginalTypeDefinitions.FirstOrDefault(type =>
                    type.AssemblyIdentity == FullName && string.Equals(type.Identity, name, comparison));
                if (gameType != null)
                    return _members.GetActualSourceType(FullName, gameType.Identity);
            }
            else
            {
                var gameType = _members.GetActualSourceType(FullName, name);
                if (gameType != null)
                    return gameType;
            }

            if (_order is ISourceRuntimeTypeAliasResolver aliases)
            {
                var aliasType = aliases.ResolveRuntimeTypeAlias(name, ignoreCase);
                if (aliasType != null)
                    return aliasType;
            }

            if (throwOnError)
                throw new TypeLoadException("Could not load type '" + name + "' from original source assembly '" +
                                            FullName + "'.");
            return null;
        }

        public bool NameMatches(Type type, string name, bool allowShortName = false, bool ignoreCase = false)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (name == null)
                return false;
            var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            if (string.Equals(type.FullName, name, comparison) ||
                (allowShortName && string.Equals(type.Name, name, comparison)))
                return true;
            if (_members.ContainsSourceType(type))
            {
                var logicalName = _members.GetOriginalTypeFullName(type);
                if (string.Equals(logicalName, name, comparison))
                    return true;
                if (allowShortName)
                {
                    var separator = Math.Max(logicalName.LastIndexOf('.'), logicalName.LastIndexOf('+'));
                    if (string.Equals(logicalName.Substring(separator + 1), name, comparison))
                        return true;
                }
            }

            return _order is ISourceRuntimeTypeAliasResolver aliases &&
                   aliases.RuntimeTypeNameMatches(type, name, allowShortName, ignoreCase);
        }

        public string[] GetManifestResourceNames()
        {
            return _resources.GetManifestResourceNames(FullName);
        }

        public Stream GetManifestResourceStream(string name)
        {
            return _resources.GetManifestResourceStream(FullName, name);
        }

        public Stream GetManifestResourceStream(Type type, string name)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!_members.ContainsSourceType(type))
                return type.Assembly.GetManifestResourceStream(type, name);
            var identity = _members.GetOriginalTypeFullName(type);
            var nested = identity.IndexOf('+');
            if (nested >= 0)
                identity = identity[..nested];
            var separator = identity.LastIndexOf('.');
            return GetManifestResourceStream(separator < 0 ? name : identity[..separator] + "." + name);
        }

        public AssemblyName GetName()
        {
            return new(FullName);
        }
    }
}
