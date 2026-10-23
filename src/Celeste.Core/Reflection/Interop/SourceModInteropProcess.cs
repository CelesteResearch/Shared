using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Core.Reflection.Interop
{
    public sealed class SourceModInteropProcess
    {
        public SourceModInteropBindingCatalog TypeBindings { get; }
        public event Action ImportsRefreshed;
        private bool notifyingImports;
        private readonly SourceMemberCatalog sourceMembers;
        private readonly SourceAssemblyMethodCatalog sourceMethods;

        public SourceModInteropProcess(SourceModInteropBindingCatalog typeBindings,
            SourceMemberCatalog sourceMembers, SourceAssemblyMethodCatalog sourceMethods)
        {
            TypeBindings = typeBindings ?? throw new ArgumentNullException(nameof(typeBindings));
            this.sourceMembers = sourceMembers ?? throw new ArgumentNullException(nameof(sourceMembers));
            this.sourceMethods = sourceMethods ?? throw new ArgumentNullException(nameof(sourceMethods));
        }

        public void ModInterop(Type actualType)
        {
            RequireMutationAllowed();
            ModInterop(TypeBindings.PublishActualType(sourceMembers, sourceMethods, actualType));
        }

        private readonly HashSet<Type> registered = new();
        private readonly Dictionary<string, List<SourceModInteropExportCandidate>> methods = new();
        private readonly List<(SourceModInteropTypeBinding Type, SourcePhysicalMemberBinding Field)> fields = new();

        public void ModInterop(SourceModInteropTypeBinding type)
        {
            RequireMutationAllowed();
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (registered.Contains(type.ActualType)) return;
            registered.Add(type.ActualType);
            string name = type.GetExportName();
            foreach (SourcePhysicalMemberBinding field in type.Fields)
            {
                if (typeof(Delegate).IsAssignableFrom(field.ValueType)) fields.Add((type, field));
            }

            foreach (SourceModInteropMethodBinding method in type.Methods)
            {
                RegisterModExport(method);
                RegisterModExport(method, name);
            }

            RefreshImports();
        }

        private readonly HashSet<SourceModInteropActualTypeBinding> owned = new();
        private readonly List<(SourceModInteropActualTypeBinding Type, FieldInfo Field)> actualFields = new();

        public IDisposable RegisterOwned(SourceModInteropActualTypeBinding type)
        {
            RequireMutationAllowed();
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (owned.Contains(type))
                throw new InvalidOperationException("The owned interop binding is already registered.");
            var restore = CaptureImportValues();
            foreach (var field in type.Fields)
            {
                object value = field.GetValue(type.ActualOwner);
                restore.Add(() => field.SetValue(type.ActualOwner, value));
            }

            var exports = new List<(string Name, SourceModInteropExportCandidate Method)>();
            owned.Add(type);
            foreach (var field in type.Fields) actualFields.Add((type, field));
            try
            {
                foreach (var method in type.Methods)
                {
                    var candidate =
                        new SourceModInteropExportCandidate(method, method.IsStatic ? null : type.ActualOwner);
                    string name = type.GetExportName(method);
                    Add(name, candidate);
                    if (!string.IsNullOrEmpty(type.ExportName)) Add(type.ExportName + "." + name, candidate);
                }

                RefreshImports();
            }
            catch (Exception registrationError)
            {
                RemoveOwned();
                for (int index = restore.Count - 1; index >= 0; index--) restore[index]();
                try
                {
                    NotifyImportsRefreshed();
                }
                catch (Exception rollbackError)
                {
                    throw new AggregateException(registrationError, rollbackError);
                }

                throw;
            }

            return new SourceModInteropRegistrationLease(() =>
            {
                RemoveOwned();
                foreach (var field in type.Fields) field.SetValue(type.ActualOwner, null);
                RefreshImports();
            }, RequireMutationAllowed);

            void Add(string name, SourceModInteropExportCandidate candidate)
            {
                if (!methods.TryGetValue(name, out var candidates)) methods[name] = candidates = new();
                candidates.Add(candidate);
                exports.Add((name, candidate));
            }

            void RemoveOwned()
            {
                owned.Remove(type);
                actualFields.RemoveAll(entry => ReferenceEquals(entry.Type, type));
                foreach (var export in exports)
                {
                    var candidates = methods[export.Name];
                    candidates.Remove(export.Method);
                    if (candidates.Count == 0) methods.Remove(export.Name);
                }
            }
        }

        private List<Action> CaptureImportValues()
        {
            var restore = new List<Action>();
            foreach (var entry in fields)
            {
                var field = entry.Field;
                object value = field.Read(null);
                restore.Add(() => field.Write(null, value));
            }

            foreach (var entry in actualFields)
            {
                var type = entry.Type;
                var field = entry.Field;
                object value = field.GetValue(type.ActualOwner);
                restore.Add(() => field.SetValue(type.ActualOwner, value));
            }

            return restore;
        }

        private void RefreshImports()
        {
            foreach (var entry in fields)
                BindLegacyImport(entry.Type.GetModImportName(entry.Field), entry.Field);
            foreach (var entry in actualFields)
                entry.Field.SetValue(entry.Type.ActualOwner,
                    FindDelegate(entry.Type.GetImportName(entry.Field), entry.Field.FieldType));
            NotifyImportsRefreshed();
        }

        private void NotifyImportsRefreshed()
        {
            if (ImportsRefreshed == null) return;
            List<Exception> failures = null;
            notifyingImports = true;
            try
            {
                foreach (Action callback in ImportsRefreshed.GetInvocationList())
                {
                    try
                    {
                        callback();
                    }
                    catch (Exception error)
                    {
                        (failures ??= new()).Add(error);
                    }
                }
            }
            finally
            {
                notifyingImports = false;
            }

            if (failures != null) throw new AggregateException(failures);
        }

        private void RequireMutationAllowed()
        {
            if (notifyingImports)
                throw new InvalidOperationException("Interop registration cannot change during import notification.");
        }

        private void BindLegacyImport(string name, SourcePhysicalMemberBinding field)
        {
            if (methods.TryGetValue(name, out var candidates))
                foreach (var candidate in candidates)
                {
                    try
                    {
                        field.Write(null,
                            Delegate.CreateDelegate(field.ValueType, candidate.ActualOwner, candidate.ActualMethod));
                        return;
                    }
                    catch
                    {
                        continue;
                    }
                }

            field.Write(null, null);
        }

        private Delegate FindDelegate(string name, Type delegateType)
        {
            if (!methods.TryGetValue(name, out var candidates)) return null;
            foreach (var candidate in candidates)
            {
                try
                {
                    return Delegate.CreateDelegate(delegateType, candidate.ActualOwner, candidate.ActualMethod);
                }
                catch
                {
                    continue;
                }
            }

            return null;
        }

        public void RegisterModExport(SourceModInteropMethodBinding method, string prefix = null)
        {
            RequireMutationAllowed();
            if (method == null) throw new ArgumentNullException(nameof(method));
            var attributes = (MethodAttributes)method.Definition.Attributes;
            if ((attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public ||
                (attributes & MethodAttributes.Static) == 0)
                throw new MemberAccessException("Utility must be public static");
            string name = method.Definition.Name;
            if (!string.IsNullOrEmpty(prefix)) name = prefix + "." + name;
            if (!methods.TryGetValue(name, out var candidates)) methods[name] = candidates = new();
            bool exists = false;
            foreach (var candidate in candidates)
                if (candidate.SourceDefinition != null &&
                    candidate.SourceDefinition.AssemblyIdentity == method.Definition.AssemblyIdentity &&
                    candidate.SourceDefinition.MethodDefinitionToken == method.Definition.MethodDefinitionToken)
                {
                    exists = true;
                    break;
                }

            if (!exists)
                candidates.Add(new SourceModInteropExportCandidate(
                    method.Method.ActualMethod, method.Method.ActualOwner, method.Definition));
        }
    }
}
