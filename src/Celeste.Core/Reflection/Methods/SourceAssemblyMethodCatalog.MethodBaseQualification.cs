using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Methods
{
    public sealed partial class SourceAssemblyMethodCatalog
    {
        public bool TryGetOriginalMethodDefinition(MethodBase actualMethod, out SourceMethodDefinition definition)
        {
            if (actualMethod == null) throw new ArgumentNullException(nameof(actualMethod));
            if (actualMethod is MethodInfo method)
                return originalMethods.TryGetValue(method, out definition);
            if (actualMethod is ConstructorInfo constructor)
                foreach (var assembly in assemblies.Values)
                foreach (var entry in assembly.Values)
                    if (entry.ActualConstructor == constructor)
                    {
                        definition = entry.Definition;
                        return true;
                    }

            definition = null;
            return false;
        }

        public SourceMethodDefinition RequireOriginalMethodDefinition(MethodBase actualMethod)
        {
            return TryGetOriginalMethodDefinition(actualMethod, out var definition)
                ? definition
                : throw new InvalidOperationException("Actual source method metadata is not bound: " + actualMethod);
        }

        public bool TryGetOriginalMethodDefinition(SourceMemberCatalog members, MethodBase actualMethod,
            out SourceMethodDefinition definition)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            // A qualified declaring type does not give every new portable helper an original MethodDef.
            // Diagnostics can display the actual CLR method when no exact method binding exists.
            return TryGetOriginalMethodDefinition(actualMethod, out definition);
        }

        private readonly Dictionary<Type, SourceTypeDefinition> actualHelperFrameOrigins = new();

        public void RegisterActualHelperFrameOwnership(SourceMemberCatalog members, Type actualHelperType,
            Type qualifiedSourceOwnerType)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            if (actualHelperType == null) throw new ArgumentNullException(nameof(actualHelperType));
            if (actualHelperType.Assembly.IsDynamic)
                throw new InvalidOperationException("A dynamic helper type has no qualified physical metadata owner.");
            var origin = members.GetOriginalTypeDefinition(qualifiedSourceOwnerType);
            if (actualHelperFrameOrigins.TryGetValue(actualHelperType, out var existing))
            {
                if (existing.AssemblyIdentity != origin.AssemblyIdentity || existing.Identity != origin.Identity)
                    throw new InvalidOperationException(
                        "Actual helper frame ownership was registered with a different source origin.");
                return;
            }

            actualHelperFrameOrigins.Add(actualHelperType, origin);
        }

        // The original stack-frame algorithm needs the assembly owner, not an invented MethodDef
        // for a new portable helper. An explicitly qualified declaring type proves that owner.
        public string RequireFrameSourceAssemblyIdentity(SourceMemberCatalog members, MethodBase actualMethod)
        {
            if (TryGetFrameSourceAssemblyIdentity(members, actualMethod, out var assemblyIdentity))
                return assemblyIdentity;
            throw new InvalidOperationException(
                "The stack frame has no qualified source assembly owner; its actual runtime SDK or source-helper admission must be established: " +
                actualMethod);
        }

        public bool TryGetFrameSourceAssemblyIdentity(SourceMemberCatalog members, MethodBase actualMethod,
            out string assemblyIdentity)
        {
            if (members == null) throw new ArgumentNullException(nameof(members));
            if (actualMethod == null) throw new ArgumentNullException(nameof(actualMethod));
            if (TryGetOriginalMethodDefinition(actualMethod, out var methodDefinition))
            {
                assemblyIdentity = methodDefinition.AssemblyIdentity;
                return true;
            }

            if (actualHelperOperationFrameOrigins.TryGetValue(actualMethod, out var operation))
            {
                assemblyIdentity = operation.AssemblyIdentity;
                return true;
            }

            if (actualHelperMethodFrameOrigins.TryGetValue(actualMethod, out var helperOwner))
            {
                assemblyIdentity = helperOwner.AssemblyIdentity;
                return true;
            }

            var declaringType = actualMethod.DeclaringType;
            while (declaringType != null)
            {
                if (members.ContainsSourceType(declaringType))
                {
                    assemblyIdentity = members.GetOriginalTypeDefinition(declaringType).AssemblyIdentity;
                    return true;
                }

                if (actualHelperFrameOrigins.TryGetValue(declaringType, out var helperOrigin))
                {
                    assemblyIdentity = helperOrigin.AssemblyIdentity;
                    return true;
                }

                // This proves actual compiler nesting only; it never invents an original TypeDef.
                var parent = declaringType.DeclaringType;
                if (!declaringType.IsNested || parent == null || declaringType.Assembly.IsDynamic
                    || !declaringType.IsDefined(typeof(CompilerGeneratedAttribute), false)
                    || (declaringType.MetadataToken & unchecked((int)0xff000000)) != 0x02000000
                    || declaringType.Module != parent.Module || declaringType.Assembly != parent.Assembly)
                    break;
                declaringType = parent;
            }

            assemblyIdentity = null;
            return false;
        }
    }
}
