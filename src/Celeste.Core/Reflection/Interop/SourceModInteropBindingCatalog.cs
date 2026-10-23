using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Core.Reflection.Interop
{
    public sealed class SourceModInteropBindingCatalog
    {
        private readonly Dictionary<Type, SourceModInteropTypeBinding> types = new();

        public void Register(SourceModInteropTypeBinding binding)
        {
            if (binding == null) throw new ArgumentNullException(nameof(binding));
            types.Add(binding.ActualType, binding);
        }

        public SourceModInteropTypeBinding PublishActualType(SourceMemberCatalog members,
            SourceAssemblyMethodCatalog methods, Type actualType)
        {
            if (types.TryGetValue(actualType, out var existing)) return existing;
            var definition = members.GetOriginalTypeDefinition(actualType);
            var fields = members.GetAllMembers(actualType, SourceMemberKind.Field,
                BindingFlags.Public | BindingFlags.Static).ToArray();
            var selections = methods.GetMethods(members, actualType,
                    BindingFlags.Public | BindingFlags.Static).Select(method => new SourceModInteropMethodBinding(
                    methods.RequireDefinition(method.SourceAssemblyIdentity, method.SourceMethodDefinitionToken),
                    method))
                .ToArray();
            var binding = new SourceModInteropTypeBinding(definition, actualType,
                definition.DeclaredAttributes, fields, selections);
            Register(binding);
            return binding;
        }

        public SourceModInteropTypeBinding Require(Type actualType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            return types.TryGetValue(actualType, out var binding)
                ? binding
                : throw new InvalidOperationException(
                    "The complete original ModInterop type facts and same-process bindings are not published: " +
                    actualType.FullName);
        }
    }
}
