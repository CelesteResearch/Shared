using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Reflection;

namespace Celeste.Everest.Content.Extensions.Entities.Registry
{
    public sealed partial class EverestEntityRegistryProcess
    {
        private readonly Dictionary<string, HashSet<Type>> SidToTypes = new();
        private readonly Dictionary<Type, HashSet<string>> TypeToSids = new();
        private readonly HashSet<Type> EmptyTypeSet = [];
        private readonly HashSet<string> EmptyStringSet = [];
        private readonly SourceReflectionTypeSafetyState typeInspection;
        private readonly SourceMemberCatalog members;

        internal EverestEntityRegistryProcess(SourceEverestReflectionProcessState reflection)
        {
            if (reflection == null) throw new ArgumentNullException(nameof(reflection));
            typeInspection = reflection.TypeSafety;
            members = reflection.SourceMembers;
        }

        public HashSet<Type> GetKnownTypesFromSid(string sid)
        {
            SidToTypes.TryGetValue(sid, out var types);
            return types ?? EmptyTypeSet;
        }

        public HashSet<string> GetKnownSidsFromType(Type type)
        {
            TypeToSids.TryGetValue(type, out var sids);
            return sids ?? EmptyStringSet;
        }

        public void RegisterSidToTypeConnection(string sid, Type type)
        {
            if (sid == null || (object)type == null)
                return;
            if (!SidToTypes.TryGetValue(sid, out var types))
                SidToTypes.Add(sid, null);
            if (types == null)
            {
                types = new(1);
                SidToTypes[sid] = types;
            }

            types.Add(type);
            if (!TypeToSids.TryGetValue(type, out var sids))
                TypeToSids.Add(type, null);
            if (sids == null)
            {
                sids = new(1);
                TypeToSids[type] = sids;
            }

            sids.Add(sid);
        }

        public IDisposable RegisterOwnedSidToTypeConnection(string sid, Type type)
        {
            var existed = GetKnownTypesFromSid(sid).Contains(type);
            RegisterSidToTypeConnection(sid, type);
            return new RegistrationUndo(() =>
            {
                if (existed) return;
                if (SidToTypes.TryGetValue(sid, out var types))
                {
                    types.Remove(type);
                    if (types.Count == 0) SidToTypes.Remove(sid);
                }

                if (TypeToSids.TryGetValue(type, out var sids))
                {
                    sids.Remove(sid);
                    if (sids.Count == 0) TypeToSids.Remove(type);
                }
            });
        }

        public void OnModAssemblyUnload(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            foreach (var type in TypeToSids.Keys.Where(type => type.Assembly == assembly).ToArray())
                TypeToSids.Remove(type);
            foreach (var pair in SidToTypes)
                pair.Value.RemoveWhere(type => type.Assembly == assembly);
        }

        public void OnModAssemblyUnload(string originalAssemblyIdentity)
        {
            if (originalAssemblyIdentity == null) throw new ArgumentNullException(nameof(originalAssemblyIdentity));
            // The original input is one logical module assembly. A port may physically split or merge
            // that assembly, so use its genuine PE type order and strictly qualified actual type view.
            var sourceTypes = members.OriginalTypeDefinitions
                .Where(definition => definition.AssemblyIdentity == originalAssemblyIdentity)
                .OrderBy(definition => definition.MetadataToken).ToArray();
            if (sourceTypes.Length == 0)
                throw new InvalidOperationException(
                    "The original module assembly type universe has not been published: " +
                    originalAssemblyIdentity);
            var types = sourceTypes
                .Select(definition => members.GetActualSourceType(definition.AssemblyIdentity, definition.Identity)
                                      ?? throw new InvalidOperationException(
                                          "The original module type has no qualified actual representation: " +
                                          definition.Identity))
                .Where(typeInspection.IsSafe).ToHashSet();
            foreach (var type in types)
                TypeToSids.Remove(type);
            foreach (var pair in SidToTypes)
                pair.Value.RemoveWhere(type => types.Contains(type));
        }
    }
}
